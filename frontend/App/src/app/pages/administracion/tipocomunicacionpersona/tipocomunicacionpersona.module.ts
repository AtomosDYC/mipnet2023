import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipocomunicacionpersonaRoutingModule } from './tipocomunicacionpersona-routing.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    TipocomunicacionpersonaRoutingModule,
    StoreModule.forFeature('tipocompersona', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class TipocomunicacionpersonaModule { }
