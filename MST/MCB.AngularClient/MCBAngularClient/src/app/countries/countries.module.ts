import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

// 3rd Parties
import { MDBBootstrapModulesPro } from 'ng-uikit-pro-standard';
import { DxVectorMapModule } from 'devextreme-angular';

// Components
import { RootComponent } from './root/root.component';
import { RegionDetailsComponent } from './region-details/region-details.component';
import { ContinentsListComponent } from './continents-list/continents-list.component';
import { CountriesMapComponent } from './countries-map/countries-map.component';

import { routing } from './countries-routing.module';
import { CountryThumbnailComponent } from './country-thumbnail/country-thumbnail.component';




@NgModule({
  declarations: [RootComponent, RegionDetailsComponent, ContinentsListComponent, CountriesMapComponent, CountryThumbnailComponent],
  imports: [
    routing,
    CommonModule,
    FormsModule,
    MDBBootstrapModulesPro.forRoot(),
    DxVectorMapModule
  ]
})
export class CountriesModule { }