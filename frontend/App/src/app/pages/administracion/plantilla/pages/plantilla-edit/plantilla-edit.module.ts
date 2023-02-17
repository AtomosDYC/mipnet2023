import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PlantillaEditRoutingModule } from './plantilla-edit-routing.module';
import { PlantillaEditComponent } from './plantilla-edit.component';


@NgModule({
  declarations: [
    PlantillaEditComponent
  ],
  imports: [
    CommonModule,
    PlantillaEditRoutingModule
  ]
})
export class PlantillaEditModule { }
