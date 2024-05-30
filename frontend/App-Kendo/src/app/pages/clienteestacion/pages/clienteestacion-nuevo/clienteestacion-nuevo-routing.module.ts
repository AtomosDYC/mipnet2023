import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteestacionNuevoComponent } from './clienteestacion-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:ClienteestacionNuevoComponent,
    data: { titulo: 'Matenimiento de cliente estaciones' }
  },
  {
    path:':id',
    component:ClienteestacionNuevoComponent,
    data: { titulo: 'Matenimiento de cliente estaciones' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClienteestacionNuevoRoutingModule { }
