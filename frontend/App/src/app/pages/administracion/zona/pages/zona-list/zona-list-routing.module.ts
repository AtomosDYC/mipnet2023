import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ZonaListComponent } from './zona-list.component';

const routes: Routes = [
  {
    path:'',
    component:ZonaListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ZonaListRoutingModule { }
