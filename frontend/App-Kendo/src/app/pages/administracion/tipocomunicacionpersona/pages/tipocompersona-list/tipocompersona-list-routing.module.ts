import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TipocompersonaListComponent } from './tipocompersona-list.component';

const routes: Routes = [
  {
    path:'',
    component:TipocompersonaListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TipocompersonaListRoutingModule { }
