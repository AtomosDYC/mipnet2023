import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MedidaumbralRoutingModule } from './medidaumbral-routing.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MedidaumbralRoutingModule,

    StoreModule.forFeature('medidaumbral', reducers),
    EffectsModule.forFeature(effects),

  ]
})
export class MedidaumbralModule { }
