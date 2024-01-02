import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EspecieListComponent } from './especie-list.component';

const routes: Routes = [
  {
    path:'',
    component:EspecieListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EspecieListRoutingModule { }
