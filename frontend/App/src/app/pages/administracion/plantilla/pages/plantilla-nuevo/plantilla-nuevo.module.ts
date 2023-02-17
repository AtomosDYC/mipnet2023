import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PlantillaNuevoRoutingModule } from './plantilla-nuevo-routing.module';
import { PlantillaNuevoComponent } from './plantilla-nuevo.component';


@NgModule({
  declarations: [
    PlantillaNuevoComponent
  ],
  imports: [
    CommonModule,
    PlantillaNuevoRoutingModule
  ]
})
export class PlantillaNuevoModule { }
