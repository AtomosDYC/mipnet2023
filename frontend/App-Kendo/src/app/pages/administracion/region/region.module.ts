import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegionRoutingModule } from './region-routing.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RegionRoutingModule,

    StoreModule.forFeature('region', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class RegionModule { }
