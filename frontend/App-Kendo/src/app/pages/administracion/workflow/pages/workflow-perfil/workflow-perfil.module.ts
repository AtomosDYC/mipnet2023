import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WorkflowPerfilComponent } from './workflow-perfil.component';


@NgModule({
  declarations: [
    WorkflowPerfilComponent
  ],
  exports: [
    WorkflowPerfilComponent
  ],
  imports: [
    CommonModule
  ]
})
export class WorkflowPerfilModule { }
