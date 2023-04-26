import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NivelpermisoRoutingModule } from './nivelpermiso-routing.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    NivelpermisoRoutingModule,
    StoreModule.forFeature('nivelpermiso', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class NivelpermisoModule { }
