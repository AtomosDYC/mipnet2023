import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsuarioEditComponent } from './usuario-edit.component';

const routes: Routes = [
  {
    path:'',
    component:UsuarioEditComponent,
    data: { titulo: 'Matenimiento de Usuarios' }
  },
  {
    path:':id',
    component:UsuarioEditComponent,
    data: { titulo: 'Matenimiento de Usuarios' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsuarioEditRoutingModule { }
