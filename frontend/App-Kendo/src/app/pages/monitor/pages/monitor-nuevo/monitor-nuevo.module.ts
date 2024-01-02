import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MonitorNuevoRoutingModule } from './monitor-nuevo-routing.module';
import { MonitorNuevoComponent } from './monitor-nuevo.component';
import { MonitorContenedorModule } from '../monitor-contenedor/monitor-contenedor.module';
import { LayoutModule } from '@progress/kendo-angular-layout';


@NgModule({
  declarations: [
    MonitorNuevoComponent
  ],
  imports: [
    CommonModule,
    MonitorNuevoRoutingModule,
    MonitorContenedorModule,
    LayoutModule
  ]
})
export class MonitorNuevoModule { }
