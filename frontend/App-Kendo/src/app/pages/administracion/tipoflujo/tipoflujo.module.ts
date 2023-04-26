import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipoflujoRoutingModule } from './tipoflujo-routing.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    TipoflujoRoutingModule,
    StoreModule.forFeature('tipoflujo', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class TipoflujoModule { }
