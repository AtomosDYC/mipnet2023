import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClienteestacionNuevoRoutingModule } from './clienteestacion-nuevo-routing.module';
import { ClienteestacionNuevoComponent } from './clienteestacion-nuevo.component';
import { ClienteestacionContenedorModule } from '../clienteestacion-contenedor/clienteestacion-contenedor.module';
import { LayoutModule } from '@progress/kendo-angular-layout';


@NgModule({
  declarations: [
    ClienteestacionNuevoComponent
  ],
  imports: [
    CommonModule,
    ClienteestacionNuevoRoutingModule,
    ClienteestacionContenedorModule,
    LayoutModule
  ]
})
export class ClienteestacionNuevoModule { }
