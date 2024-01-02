import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TemporadaListComponent } from './temporada-list.component';

const routes: Routes = [
  {
    path:'',
    component:TemporadaListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TemporadaListRoutingModule { }
