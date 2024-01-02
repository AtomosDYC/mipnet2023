import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EspecieNuevoRoutingModule } from './especie-nuevo-routing.module';
import { EspecieNuevoComponent } from './especie-nuevo.component';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { EspecieContenedorModule } from '../especie-contenedor/especie-contenedor.module';


@NgModule({
  declarations: [
    EspecieNuevoComponent
  ],
  imports: [
    CommonModule,
    EspecieNuevoRoutingModule,
    EspecieContenedorModule,
    LayoutModule
  ]
})
export class EspecieNuevoModule { }
