import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MedidaumbralListComponent } from './medidaumbral-list.component';

const routes: Routes = [
  {
    path:'',
    component:MedidaumbralListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MedidaumbralListRoutingModule { }
