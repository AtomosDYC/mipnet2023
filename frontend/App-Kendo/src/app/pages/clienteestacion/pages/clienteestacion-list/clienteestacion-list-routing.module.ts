import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteestacionListComponent } from './clienteestacion-list.component';

const routes: Routes = [
  {
    path:'',
    component:ClienteestacionListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClienteestacionListRoutingModule { }
