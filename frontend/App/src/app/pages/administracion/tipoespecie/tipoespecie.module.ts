import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipoespecieRoutingModule } from './tipoespecie-routing.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';


@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    TipoespecieRoutingModule,

    StoreModule.forFeature('tipoespecie', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class TipoespecieModule { }
