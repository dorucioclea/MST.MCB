import { Component, OnInit } from '@angular/core';
import View from 'ol/View';
import { fromLonLat } from 'ol/proj.js';
import TileLayer from 'ol/layer/Tile';
import OSM from 'ol/source/OSM';
import { MangolConfig, MangolLayer } from 'mangol';

@Component({
  selector: 'app-region-map-mangol',
  templateUrl: './region-map-mangol.component.html',
  styleUrls: ['./region-map-mangol.component.scss']
})
export class RegionMapMangolComponent implements OnInit {
  
  mangolConfig: MangolConfig;
  constructor() { }

  ngOnInit() {
    this.mangolConfig = {
      map: {
        target: 'mangol-demo',
        view: new View({
          projection: 'EPSG:900913',
          center: fromLonLat(
            [19.3956393810065, 47.168464955013],
            'EPSG:900913'
          ),
          zoom: 4
        }),
        layers: [
          new MangolLayer({
            name: 'OpenStreetMap Layer',
            details: 'Here are the OSM layer details',
            layer: new TileLayer({
              source: new OSM(),
              visible: true
            })
          })
        ]
      },
      sidebar: {
        opened: true,
        toolbar: {
          layertree: {},
          measure: {}
        }
      }
    };
  }
}