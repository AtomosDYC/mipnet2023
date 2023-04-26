import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SaludoRoutingModule } from './saludo-routing.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SaludoRoutingModule,  
    StoreModule.forFeature('saludo', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class SaludoModule { }
