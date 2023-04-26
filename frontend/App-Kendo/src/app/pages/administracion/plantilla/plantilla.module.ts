import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PlantillaRoutingModule } from './plantilla-routing.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';
import { PlantillaNuevoRoutingModule } from './pages/plantilla-nuevo/plantilla-nuevo-routing.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    PlantillaRoutingModule,
    PlantillaNuevoRoutingModule,
    
    StoreModule.forFeature('plantilla', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class PlantillaModule { }
