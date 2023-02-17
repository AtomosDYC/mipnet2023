import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ComunaRoutingModule } from './comuna-routing.module';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { reducers, effects } from './store/index';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ComunaRoutingModule,
    StoreModule.forFeature('comuna', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class ComunaModule { }
