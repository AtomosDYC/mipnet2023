import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EstadodanioListComponent } from './estadodanio-list.component';

const routes: Routes = [
  {
    path:'',
    component:EstadodanioListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EstadodanioListRoutingModule { }
