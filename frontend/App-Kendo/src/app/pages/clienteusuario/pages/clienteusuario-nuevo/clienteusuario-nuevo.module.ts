import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClienteusuarioNuevoRoutingModule } from './clienteusuario-nuevo-routing.module';
import { ClienteusuarioNuevoComponent } from './clienteusuario-nuevo.component';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { ClienteusuarioContenedorModule } from '../clienteusuario-contenedor/clienteusuario-contenedor.module';


@NgModule({
  declarations: [
    ClienteusuarioNuevoComponent
  ],
  imports: [
    CommonModule,
    ClienteusuarioNuevoRoutingModule,
    ClienteusuarioContenedorModule,
    LayoutModule
  ]
})
export class ClienteusuarioNuevoModule { }
