import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteusuarioNuevoComponent } from './clienteusuario-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:ClienteusuarioNuevoComponent,
    data: { titulo: 'Mantenimiento de cliente usuarios' }
  },
  {
    path:':id',
    component:ClienteusuarioNuevoComponent,
    data: { titulo: 'Mantenimiento de cliente usuarios' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClienteusuarioNuevoRoutingModule { }
