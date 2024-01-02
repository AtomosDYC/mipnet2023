import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TemporadabaseListComponent } from './temporadabase-list.component';

const routes: Routes = [
  {
    path:'',
    component:TemporadabaseListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TemporadabaseListRoutingModule { }
