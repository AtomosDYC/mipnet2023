import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TipoparametroListComponent } from './tipoparametro-list.component';

const routes: Routes = [
  {
    path:'',
    component:TipoparametroListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TipoparametroListRoutingModule { }
