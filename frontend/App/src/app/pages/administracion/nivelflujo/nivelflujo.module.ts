import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NivelflujoRoutingModule } from './nivelflujo-routing.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    NivelflujoRoutingModule,
    StoreModule.forFeature('nivelflujo', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class NivelflujoModule { }
