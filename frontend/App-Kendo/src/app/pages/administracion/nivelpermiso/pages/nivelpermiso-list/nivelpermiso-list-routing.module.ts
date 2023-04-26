import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NivelpermisoListComponent } from './nivelpermiso-list.component';

const routes: Routes = [
  {
    path:'',
    component:NivelpermisoListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NivelpermisoListRoutingModule { }
