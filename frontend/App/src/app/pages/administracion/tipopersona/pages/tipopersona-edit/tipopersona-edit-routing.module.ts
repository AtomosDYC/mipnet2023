import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TipopersonaEditComponent } from './tipopersona-edit.component';

const routes: Routes = [
  {
    path:':id',
    component:TipopersonaEditComponent,
    data: { titulo: 'Matenimiento de Regiones' }
  },
  {
    path: '',
    component:TipopersonaEditComponent,
    data: { titulo: 'Matenimiento de Regiones' }
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TipopersonaEditRoutingModule { }
