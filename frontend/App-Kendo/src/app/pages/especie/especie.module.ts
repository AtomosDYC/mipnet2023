import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EspecieRoutingModule } from './especie-routing.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { effects, reducers } from './pages/store';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    EspecieRoutingModule,
    StoreModule.forFeature('especie', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class EspecieModule { }
