import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';
import { TipopercomunicacionListModule } from './pages/tipopercomunicacion-list/tipopercomunicacion-list.module';


@NgModule({
  declarations: [],
  exports: [
    TipopercomunicacionListModule,
  ],
  imports: [
    CommonModule,
    TipopercomunicacionListModule,
    StoreModule.forFeature('tipopercomunicacion', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class TipopercomunicacionModule { }


