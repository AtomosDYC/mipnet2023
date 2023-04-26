import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SaludoListComponent } from './saludo-list.component';

const routes: Routes = [
  {
    path:'',
    component:SaludoListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SaludoListRoutingModule { }
