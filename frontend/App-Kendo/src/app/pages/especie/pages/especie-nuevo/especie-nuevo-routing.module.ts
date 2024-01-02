import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EspecieNuevoComponent } from './especie-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:EspecieNuevoComponent,
    data: { titulo: 'Matenimiento de Especies' }
  },
  {
    path:':id',
    component:EspecieNuevoComponent,
    data: { titulo: 'Matenimiento de Especies' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EspecieNuevoRoutingModule { }
