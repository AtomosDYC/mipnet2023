import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EstacionDatosgeneralesComponent } from './estacion-datosgenerales.component';



@NgModule({
  declarations: [
    EstacionDatosgeneralesComponent
  ],
  exports: [
    EstacionDatosgeneralesComponent
  ],
  imports: [
    CommonModule
  ]
})
export class EstacionDatosgeneralesModule { }
