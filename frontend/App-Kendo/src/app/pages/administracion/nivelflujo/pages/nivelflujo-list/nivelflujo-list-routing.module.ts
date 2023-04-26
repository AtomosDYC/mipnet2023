import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NivelflujoListComponent } from './nivelflujo-list.component';


const routes: Routes = [
  {
    path:'',
    component:NivelflujoListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NivelflujoListRoutingModule { }
