import { Component, OnInit, Input } from '@angular/core';

import * as mapsData from 'devextreme/dist/js/vectormap-data/world.js';

// Models
import { CountryWithAssessment } from 'src/app/core/model/Geo/country-with-assessment.model';

@Component({
  selector: 'app-country-list-for-region',
  templateUrl: './country-list-for-region.component.html',
  styleUrls: ['./country-list-for-region.component.scss']
})
export class CountryListForRegionComponent implements OnInit {

  worldMap: any = mapsData.world;

  constructor() { }

  @Input() countriesForRegion: CountryWithAssessment[];

  ngOnInit() {
    this.customizeLayers = this.customizeLayers.bind(this);
  }

  customizeLayers(elements) {
    elements.forEach((element) => {

    })
  }
  
}
