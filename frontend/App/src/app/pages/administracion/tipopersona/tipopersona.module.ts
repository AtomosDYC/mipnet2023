import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipopersonaRoutingModule } from './tipopersona-routing.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    TipopersonaRoutingModule,
    StoreModule.forFeature('tipopersona', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class TipopersonaModule { }
