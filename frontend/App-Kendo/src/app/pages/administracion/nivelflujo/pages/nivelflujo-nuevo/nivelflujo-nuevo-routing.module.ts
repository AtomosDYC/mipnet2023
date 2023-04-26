import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NivelflujoNuevoComponent } from './nivelflujo-nuevo.component';


const routes: Routes = [
  {
    path:'',
    component:NivelflujoNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo de Personas' }
  },
  {
    path:':id',
    component:NivelflujoNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo Personas' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NivelflujoNuevoRoutingModule { }
