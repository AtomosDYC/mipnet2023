import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TipoflujoNuevoComponent } from './tipoflujo-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:TipoflujoNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo de Flujo' }
  },
  {
    path:':id',
    component:TipoflujoNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo Flujo' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TipoflujoNuevoRoutingModule { }
