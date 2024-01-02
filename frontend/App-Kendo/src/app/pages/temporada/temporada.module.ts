import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TemporadaRoutingModule } from './temporada-routing.module';

import { effects, reducers } from './store';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';

@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule,
    TemporadaRoutingModule,
    StoreModule.forFeature('temporada', reducers),
    EffectsModule.forFeature(effects),
    
  ]
})
export class TemporadaModule { }
