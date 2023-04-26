import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EstadodanioNuevoComponent } from './estadodanio-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:EstadodanioNuevoComponent,
    data: { titulo: 'Matenimiento de Estados de Daño' }
  },
  {
    path:':id',
    component:EstadodanioNuevoComponent,
    data: { titulo: 'Matenimiento de Estados de Danño' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EstadodanioNuevoRoutingModule { }
