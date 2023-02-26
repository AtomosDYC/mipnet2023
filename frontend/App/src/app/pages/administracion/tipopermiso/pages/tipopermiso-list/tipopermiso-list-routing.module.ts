import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TipopermisoListComponent } from './tipopermiso-list.component';

const routes: Routes = [
  {
    path:'',
    component:TipopermisoListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TipopermisoListRoutingModule { }
