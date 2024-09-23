import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClienteusuarioContenedorComponent } from './clienteusuario-contenedor.component';
import { ClienteusuarioDatosgeneralesModule } from '../clienteusuario-datosgenerales/clienteusuario-datosgenerales.module';



@NgModule({
  declarations: [
    ClienteusuarioContenedorComponent
  ],
  imports: [
    CommonModule,
    ClienteusuarioDatosgeneralesModule
  ],
  exports: [
    ClienteusuarioContenedorComponent
  ]
})
export class ClienteusuarioContenedorModule { }
