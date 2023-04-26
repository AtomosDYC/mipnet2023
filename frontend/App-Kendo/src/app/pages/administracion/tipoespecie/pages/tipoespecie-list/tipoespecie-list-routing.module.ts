import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TipoespecieListComponent } from './tipoespecie-list.component';

const routes: Routes = [
  {
    path:'',
    component:TipoespecieListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TipoespecieListRoutingModule { }
