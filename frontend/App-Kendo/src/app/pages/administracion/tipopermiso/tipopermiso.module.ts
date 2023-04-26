import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipopermisoRoutingModule } from './tipopermiso-routing.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';

@NgModule({
  declarations: [
    
  ],
  imports: [
    CommonModule,
    TipopermisoRoutingModule,
    StoreModule.forFeature('tipopermiso', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class TipopermisoModule { }
