import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TipoflujoListComponent } from './tipoflujo-list.component';

const routes: Routes = [
  {
    path:'',
    component:TipoflujoListComponent
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TipoflujoListRoutingModule { }
