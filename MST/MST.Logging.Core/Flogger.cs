﻿using Serilog;
using Serilog.Events;
using System;
using System.Data.SqlClient;
using System.IO;

namespace MST.Flogging.Core
{
    public static class Flogger
    {
        private static readonly ILogger _perfLogger;
        private static readonly ILogger _usageLogger;
        private static readonly ILogger _errorLogger;
        private static readonly ILogger _diagnosticLogger;

        static Flogger()
        {
            _perfLogger = new LoggerConfiguration()
                .WriteTo.File(path: Path.Combine(AppContext.BaseDirectory, "Logs\\perf.txt")) 
                .CreateLogger();

            _usageLogger = new LoggerConfiguration()
                .WriteTo.File(path: Path.Combine(AppContext.BaseDirectory, "Logs\\usage.txt"))
                .CreateLogger();

            _errorLogger = new LoggerConfiguration() 
                .WriteTo.File(path: Path.Combine(AppContext.BaseDirectory, "Logs\\error.txt"))
                .CreateLogger();

            _diagnosticLogger = new LoggerConfiguration()
                .WriteTo.File(path: Path.Combine(AppContext.BaseDirectory, "Logs\\diagnostic.txt"))
                .CreateLogger();
        }

        public static void WritePerf(FlogDetail infoToLog)
        {
            _perfLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
        }

        public static void WriteUsage(FlogDetail infoToLog)
        {
            _usageLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
        }

        public static void WriteError(FlogDetail infoToLog)
        {
            if (infoToLog.Exception != null)
            {
                var procName = FindProcName(infoToLog.Exception);
                infoToLog.Location = string.IsNullOrEmpty(procName)
                    ? infoToLog.Location
                    : procName;
                infoToLog.Message = GetMessageFromException(infoToLog.Exception);
            }
            _errorLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
        }

        public static void WriteDiagnostic(FlogDetail infoToLog)
        {
            var writeDiagnostics =
                Convert.ToBoolean(Environment.GetEnvironmentVariable("DIAGNOSTICS_ON"));
            if (!writeDiagnostics)
                return;

            _diagnosticLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
        }

        #region PrivateMembers

        private static string GetMessageFromException(Exception ex)
        {
            if (ex.InnerException != null)
                return GetMessageFromException(ex.InnerException);

            return ex.Message;
        }

        private static string FindProcName(Exception ex)
        {
            var sqlEx = ex as SqlException;
            if (sqlEx != null)
            {
                var procName = sqlEx.Procedure;
                if (!string.IsNullOrEmpty(procName))
                    return procName;
            }

            if (!string.IsNullOrEmpty((string)ex.Data["Procedure"]))
            {
                return (string)ex.Data["Procedure"];
            }

            if (ex.InnerException != null)
                return FindProcName(ex.InnerException);

            return null;
        }

        #endregion PrivateMembers
    }
}
