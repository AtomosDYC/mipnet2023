import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PlantillaRoutingModule } from './plantilla-routing.module';
import { StoreModule } from '@ngrx/store';
import { reducers, effects } from './store/index';
import { EffectsModule } from '@ngrx/effects';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    PlantillaRoutingModule,
    StoreModule.forFeature('plantilla', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class PlantillaModule { }
