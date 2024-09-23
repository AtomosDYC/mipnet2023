import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClienteestacionContenedorComponent } from './clienteestacion-contenedor.component';
import { ClienteestacionDatosgeneralesModule } from '../clienteestacion-datosgenerales/clienteestacion-datosgenerales.module';
import { ClienteestacionComunicacionModule } from '../clienteestacion-comunicacion/clienteestacion-comunicacion.module';
import { ClienteestacionContactoModule } from '../clienteestacion-contacto/clienteestacion-contacto.module';
import { ClienteestacionEstacionesComponent } from '../clienteestacion-estaciones/clienteestacion-estaciones.component';
import { ClienteestacionEstacionesModule } from '../clienteestacion-estaciones/clienteestacion-estaciones.module';
import { EstacionDatosgeneralesModule } from '../estacion-datosgenerales/estacion-datosgenerales.module';



@NgModule({
  declarations: [
    ClienteestacionContenedorComponent
  ],
  exports :[
    ClienteestacionContenedorComponent
  ],
  imports: [
    CommonModule,
    ClienteestacionDatosgeneralesModule,
    ClienteestacionComunicacionModule,
    ClienteestacionContactoModule,
    ClienteestacionEstacionesModule,
    EstacionDatosgeneralesModule
  ]
})
export class ClienteestacionContenedorModule { }
