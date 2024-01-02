import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EspecietemporadaRoutingModule } from './especietemporada-routing.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { effects, reducers } from './store';


@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule,
    EspecietemporadaRoutingModule,
    StoreModule.forFeature('especietemporada', reducers),
    EffectsModule.forFeature(effects),

  ]
})
export class EspecietemporadaModule { }
