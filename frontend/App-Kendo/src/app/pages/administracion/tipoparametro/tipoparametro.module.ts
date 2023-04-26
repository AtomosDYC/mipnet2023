import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipoparametroRoutingModule } from './tipoparametro-routing.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    TipoparametroRoutingModule,
    StoreModule.forFeature('tipoparametro', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class TipoparametroModule { }
