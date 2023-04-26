import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WorkflowNuevoComponent } from './workflow-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:WorkflowNuevoComponent,
    data: { titulo: 'Matenimiento de Workflow' }
  },
  {
    path:':id',
    component:WorkflowNuevoComponent,
    data: { titulo: 'Matenimiento de Workflow' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkflowNuevoRoutingModule { }
