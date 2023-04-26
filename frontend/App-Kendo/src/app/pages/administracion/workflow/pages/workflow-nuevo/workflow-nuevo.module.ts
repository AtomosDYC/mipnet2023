import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WorkflowNuevoRoutingModule } from './workflow-nuevo-routing.module';
import { WorkflowNuevoComponent } from './workflow-nuevo.component';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { WorkflowContenedorModule } from '../workflow-contenedor/workflow-contenedor.module';

@NgModule({
  declarations: [
    WorkflowNuevoComponent
  ],
  imports: [
    CommonModule,
    WorkflowNuevoRoutingModule,
    WorkflowContenedorModule,

    LayoutModule
  ]
})
export class WorkflowNuevoModule { }
