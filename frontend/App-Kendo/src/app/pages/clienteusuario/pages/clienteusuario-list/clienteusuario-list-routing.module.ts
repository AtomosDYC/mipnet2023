import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteusuarioListComponent } from './clienteusuario-list.component';

const routes: Routes = [
  {
    path:'',
    component:ClienteusuarioListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClienteusuarioListRoutingModule { }
