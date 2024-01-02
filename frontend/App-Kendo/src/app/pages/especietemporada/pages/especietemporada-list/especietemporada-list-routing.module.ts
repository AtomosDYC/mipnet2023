import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EspecietemporadaListComponent } from './especietemporada-list.component';

const routes: Routes = [
  {
    path:'',
    component:EspecietemporadaListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EspecietemporadaListRoutingModule { }
