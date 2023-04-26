import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EstadodanioRoutingModule } from './estadodanio-routing.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    EstadodanioRoutingModule,
    StoreModule.forFeature('estadodanio', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class EstadodanioModule { }
