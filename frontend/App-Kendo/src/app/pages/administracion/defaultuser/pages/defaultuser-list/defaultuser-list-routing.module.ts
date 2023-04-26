import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DefaultuserListComponent } from './defaultuser-list.component';

const routes: Routes = [
  {
    path:'',
    component:DefaultuserListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DefaultuserListRoutingModule { }
