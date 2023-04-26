import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkflowContenedorComponent } from './workflow-contenedor.component';
import { WorkflowDatosgeneralesModule } from '../workflow-datosgenerales/workflow-datosgenerales.module';
import { WorkflowConfiguracionwebModule } from '../workflow-configuracionweb/workflow-configuracionweb.module';
import { WorkflowNodopadreModule } from '../workflow-nodopadre/workflow-nodopadre.module';
import { WorkflowParametrosModule } from '../workflow-parametros/workflow-parametros.module';
import { WorkflowPerfilModule } from '../workflow-perfil/workflow-perfil.module';



@NgModule({
  declarations: [
    WorkflowContenedorComponent,
  ],
  exports:[
    WorkflowContenedorComponent,
  ],
  imports: [
    CommonModule,
    WorkflowDatosgeneralesModule,
    WorkflowConfiguracionwebModule,
    WorkflowNodopadreModule,
    WorkflowParametrosModule,
    WorkflowPerfilModule,
  ]
})
export class WorkflowContenedorModule { }
