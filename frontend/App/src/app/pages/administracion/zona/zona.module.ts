import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ZonaRoutingModule } from './zona-routing.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { reducers, effects } from './store/index';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ZonaRoutingModule,

    StoreModule.forFeature('zona', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class ZonaModule { }
