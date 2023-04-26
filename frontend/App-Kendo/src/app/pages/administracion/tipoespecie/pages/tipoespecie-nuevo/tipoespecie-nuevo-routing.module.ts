import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TipoespecieNuevoComponent } from './tipoespecie-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:TipoespecieNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo de Especies' }
  },
  {
    path:':id',
    component:TipoespecieNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo de Especies' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TipoespecieNuevoRoutingModule { }
