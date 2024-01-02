import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TemporadabaseRoutingModule } from './temporadabase-routing.module';
import { effects, reducers } from './store';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';

@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule,
    TemporadabaseRoutingModule,
    StoreModule.forFeature('temporadabase', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class TemporadabaseModule { }
