import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MonitorContenedorComponent } from './monitor-contenedor.component';
import { MonitorDatosgeneralesModule } from '../monitor-datosgenerales/monitor-datosgenerales.module';
import { MonitorAccesoModule } from '../monitor-acceso/monitor-acceso.module';
import { MonitorEspeciesModule } from '../monitor-especies/monitor-especies.module';
import { MonitorMoverModule } from '../monitor-mover/monitor-mover.module';
import { MonitorTrampasModule } from '../monitor-trampas/monitor-trampas.module';
import { MonitorCelularesModule } from '../monitor-celulares/monitor-celulares.module';
import { MonitorComunicacionModule } from '../monitor-comunicacion/monitor-comunicacion.module';



@NgModule({
  declarations: [
    MonitorContenedorComponent
  ],
  exports :[
    MonitorContenedorComponent
  ],
  imports: [
    CommonModule,
    MonitorDatosgeneralesModule,
    MonitorAccesoModule,
    MonitorEspeciesModule,
    MonitorMoverModule,
    MonitorTrampasModule,
    MonitorCelularesModule,
    MonitorComunicacionModule,
  ]
})
export class MonitorContenedorModule { }
