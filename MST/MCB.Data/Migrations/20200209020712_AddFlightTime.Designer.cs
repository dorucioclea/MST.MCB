﻿// <auto-generated />
using System;
using MCB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MCB.Data.Migrations
{
    [DbContext(typeof(MCBContext))]
    [Migration("20200209020712_AddFlightTime")]
    partial class AddFlightTime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MCB.Data.Domain.Admin.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Exception");

                    b.Property<string>("Level");

                    b.Property<string>("LogEvent");

                    b.Property<string>("Message");

                    b.Property<string>("MessageTemplate");

                    b.Property<string>("Properties")
                        .HasColumnType("xml");

                    b.Property<DateTimeOffset>("TimeStamp");

                    b.HasKey("Id");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("MCB.Data.Domain.Aviation.AirLineAlliance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AirLineAlliance");
                });

            modelBuilder.Entity("MCB.Data.Domain.Aviation.Aircraft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AircraftModelId");

                    b.Property<string>("TailNumber");

                    b.HasKey("Id");

                    b.HasIndex("AircraftModelId");

                    b.ToTable("Aircraft");
                });

            modelBuilder.Entity("MCB.Data.Domain.Aviation.AircraftFactory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AircraftFactoryCountryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AircraftFactoryCountryId");

                    b.ToTable("AircraftFactory");
                });

            modelBuilder.Entity("MCB.Data.Domain.Aviation.AircraftModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AircraftFactoryId");

                    b.Property<string>("Model");

                    b.HasKey("Id");

                    b.HasIndex("AircraftFactoryId");

                    b.ToTable("AircraftModel");
                });

            modelBuilder.Entity("MCB.Data.Domain.Aviation.Airline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AirLineAllianceId");

                    b.Property<int?>("AirlineCountryId");

                    b.Property<string>("IATA");

                    b.Property<string>("ICAO");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AirLineAllianceId");

                    b.HasIndex("AirlineCountryId");

                    b.ToTable("Airline");
                });

            modelBuilder.Entity("MCB.Data.Domain.Aviation.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AirportId");

                    b.Property<string>("City");

                    b.Property<int?>("CountryId");

                    b.Property<string>("CountryName");

                    b.Property<string>("IATA");

                    b.Property<string>("ICAO");

                    b.Property<long>("Latitude");

                    b.Property<long>("Longitude");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Airport");
                });

            modelBuilder.Entity("MCB.Data.Domain.Flights.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AircraftId");

                    b.Property<int?>("AirlineId");

                    b.Property<int?>("ArrivalAirportId");

                    b.Property<DateTime?>("ArrivialDate");

                    b.Property<int?>("CombinedNextFlightId");

                    b.Property<int?>("CombinedPreviousFlightId");

                    b.Property<int?>("DepartureAirportId");

                    b.Property<DateTime?>("DepartureDate");

                    b.Property<long?>("Distance");

                    b.Property<string>("FlightNumber");

                    b.Property<long?>("FlightTime");

                    b.Property<string>("FlightTypeAssessment")
                        .IsRequired();

                    b.Property<DateTime?>("ScheduleArrivialDate");

                    b.Property<DateTime?>("ScheduleDepartureDate");

                    b.Property<int?>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("AircraftId");

                    b.HasIndex("AirlineId");

                    b.HasIndex("ArrivalAirportId");

                    b.HasIndex("CombinedNextFlightId")
                        .IsUnique()
                        .HasFilter("[CombinedNextFlightId] IS NOT NULL");

                    b.HasIndex("DepartureAirportId");

                    b.HasIndex("TripId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("MCB.Data.Domain.Geo.Continent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryCount");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Continent");
                });

            modelBuilder.Entity("MCB.Data.Domain.Geo.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alpha2Code");

                    b.Property<string>("Alpha3Code");

                    b.Property<long>("Area");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.Property<string>("OfficialName");

                    b.Property<int?>("RegionId");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("MCB.Data.Domain.Geo.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContinentId");

                    b.Property<int?>("CountriesCount");

                    b.Property<double>("MaxLatitude");

                    b.Property<double>("MaxLongitude");

                    b.Property<double>("MinLatitude");

                    b.Property<double>("MinLongitude");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ContinentId");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("MCB.Data.Domain.Trips.Stop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Arrival");

                    b.Property<int?>("CountryId");

                    b.Property<DateTime>("Departure");

                    b.Property<string>("Description");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int>("TripId");

                    b.Property<int?>("WorldHeritageId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("TripId");

                    b.HasIndex("WorldHeritageId");

                    b.ToTable("Stop");
                });

            modelBuilder.Entity("MCB.Data.Domain.Trips.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("TripManagerId");

                    b.HasKey("Id");

                    b.HasIndex("TripManagerId");

                    b.ToTable("Trip");
                });

            modelBuilder.Entity("MCB.Data.Domain.User.TUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("TUser");
                });

            modelBuilder.Entity("MCB.Data.Domain.User.UserCountry", b =>
                {
                    b.Property<int?>("CountryId");

                    b.Property<string>("TUserId");

                    b.Property<long>("AreaLevelAssessment");

                    b.Property<string>("CountryKnowledgeType")
                        .IsRequired();

                    b.HasKey("CountryId", "TUserId");

                    b.HasIndex("TUserId");

                    b.ToTable("UserCountry");
                });

            modelBuilder.Entity("MCB.Data.Domain.User.UserFlight", b =>
                {
                    b.Property<int>("FlightId");

                    b.Property<string>("TUserId");

                    b.HasKey("FlightId", "TUserId");

                    b.HasIndex("TUserId");

                    b.ToTable("UserFlight");
                });

            modelBuilder.Entity("MCB.Data.Domain.User.UserTrip", b =>
                {
                    b.Property<int>("TripId");

                    b.Property<string>("TUserId");

                    b.HasKey("TripId", "TUserId");

                    b.HasIndex("TUserId");

                    b.ToTable("UserTrip");
                });

            modelBuilder.Entity("MCB.Data.Domain.WorldHeritages.WorldHeritage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl");

                    b.Property<string>("IsoCodes");

                    b.Property<string>("Latitude");

                    b.Property<string>("Location");

                    b.Property<string>("Longitude");

                    b.Property<string>("Region");

                    b.Property<string>("UnescoId");

                    b.HasKey("Id");

                    b.ToTable("WorldHeritage");
                });

            modelBuilder.Entity("MCB.Data.Domain.WorldHeritages.WorldHeritageCountry", b =>
                {
                    b.Property<int>("WorldHeritageId");

                    b.Property<int>("CountryId");

                    b.HasKey("WorldHeritageId", "CountryId");

                    b.HasIndex("CountryId");

                    b.ToTable("WorldHeritageCountry");
                });

            modelBuilder.Entity("MCB.Data.Domain.Aviation.Aircraft", b =>
                {
                    b.HasOne("MCB.Data.Domain.Aviation.AircraftModel", "AircraftModel")
                        .WithMany("Aircrafts")
                        .HasForeignKey("AircraftModelId");
                });

            modelBuilder.Entity("MCB.Data.Domain.Aviation.AircraftFactory", b =>
                {
                    b.HasOne("MCB.Data.Domain.Geo.Country", "AircraftFactoryCountry")
                        .WithMany()
                        .HasForeignKey("AircraftFactoryCountryId");
                });

            modelBuilder.Entity("MCB.Data.Domain.Aviation.AircraftModel", b =>
                {
                    b.HasOne("MCB.Data.Domain.Aviation.AircraftFactory", "AircraftFactory")
                        .WithMany("AircraftModels")
                        .HasForeignKey("AircraftFactoryId");
                });

            modelBuilder.Entity("MCB.Data.Domain.Aviation.Airline", b =>
                {
                    b.HasOne("MCB.Data.Domain.Aviation.AirLineAlliance", "AirLineAlliance")
                        .WithMany("Airlines")
                        .HasForeignKey("AirLineAllianceId");

                    b.HasOne("MCB.Data.Domain.Geo.Country", "AirlineCountry")
                        .WithMany()
                        .HasForeignKey("AirlineCountryId");
                });

            modelBuilder.Entity("MCB.Data.Domain.Aviation.Airport", b =>
                {
                    b.HasOne("MCB.Data.Domain.Geo.Country", "Country")
                        .WithMany("Airports")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("MCB.Data.Domain.Flights.Flight", b =>
                {
                    b.HasOne("MCB.Data.Domain.Aviation.Aircraft", "Aircraft")
                        .WithMany()
                        .HasForeignKey("AircraftId");

                    b.HasOne("MCB.Data.Domain.Aviation.Airline", "Airline")
                        .WithMany("Flights")
                        .HasForeignKey("AirlineId");

                    b.HasOne("MCB.Data.Domain.Aviation.Airport", "ArrivalAirport")
                        .WithMany("ArrivalFlights")
                        .HasForeignKey("ArrivalAirportId");

                    b.HasOne("MCB.Data.Domain.Flights.Flight", "CombinedNextFlight")
                        .WithOne("CombinedPreviousFlight")
                        .HasForeignKey("MCB.Data.Domain.Flights.Flight", "CombinedNextFlightId");

                    b.HasOne("MCB.Data.Domain.Aviation.Airport", "DepartureAirport")
                        .WithMany("DepartureFlights")
                        .HasForeignKey("DepartureAirportId");

                    b.HasOne("MCB.Data.Domain.Trips.Trip", "Trip")
                        .WithMany("Flights")
                        .HasForeignKey("TripId");
                });

            modelBuilder.Entity("MCB.Data.Domain.Geo.Country", b =>
                {
                    b.HasOne("MCB.Data.Domain.Geo.Region", "Region")
                        .WithMany("Countries")
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("MCB.Data.Domain.Geo.Region", b =>
                {
                    b.HasOne("MCB.Data.Domain.Geo.Continent", "Continent")
                        .WithMany("Regions")
                        .HasForeignKey("ContinentId");
                });

            modelBuilder.Entity("MCB.Data.Domain.Trips.Stop", b =>
                {
                    b.HasOne("MCB.Data.Domain.Geo.Country", "Country")
                        .WithMany("CountryStops")
                        .HasForeignKey("CountryId");

                    b.HasOne("MCB.Data.Domain.Trips.Trip", "Trip")
                        .WithMany("Stops")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MCB.Data.Domain.WorldHeritages.WorldHeritage", "WorldHeritage")
                        .WithMany()
                        .HasForeignKey("WorldHeritageId");
                });

            modelBuilder.Entity("MCB.Data.Domain.Trips.Trip", b =>
                {
                    b.HasOne("MCB.Data.Domain.User.TUser", "TripManager")
                        .WithMany()
                        .HasForeignKey("TripManagerId");
                });

            modelBuilder.Entity("MCB.Data.Domain.User.UserCountry", b =>
                {
                    b.HasOne("MCB.Data.Domain.Geo.Country", "Country")
                        .WithMany("UserCountries")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MCB.Data.Domain.User.TUser", "TUser")
                        .WithMany("UserCountries")
                        .HasForeignKey("TUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MCB.Data.Domain.User.UserFlight", b =>
                {
                    b.HasOne("MCB.Data.Domain.Flights.Flight", "Flight")
                        .WithMany("UserFlights")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MCB.Data.Domain.User.TUser", "TUser")
                        .WithMany("UserFlights")
                        .HasForeignKey("TUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MCB.Data.Domain.User.UserTrip", b =>
                {
                    b.HasOne("MCB.Data.Domain.User.TUser", "TUser")
                        .WithMany("UserTrips")
                        .HasForeignKey("TUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MCB.Data.Domain.Trips.Trip", "Trip")
                        .WithMany("UserTrips")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MCB.Data.Domain.WorldHeritages.WorldHeritageCountry", b =>
                {
                    b.HasOne("MCB.Data.Domain.Geo.Country", "Country")
                        .WithMany("WoldHeritageCountries")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MCB.Data.Domain.WorldHeritages.WorldHeritage", "WorldHeritage")
                        .WithMany("WoldHeritageCountries")
                        .HasForeignKey("WorldHeritageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
