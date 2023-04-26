import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TipodocumentoListComponent } from './tipodocumento-list.component';

const routes: Routes = [
  {
    path:'',
    component:TipodocumentoListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TipodocumentoListRoutingModule { }
