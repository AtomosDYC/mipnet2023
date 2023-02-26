import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TipocompersonaEditComponent } from './tipocompersona-edit.component';

const routes: Routes = [
  {
    path:':id',
    component:TipocompersonaEditComponent,
    data: { titulo: 'Matenimiento de Regiones' }
  },
  {
    path: '',
    component:TipocompersonaEditComponent,
    data: { titulo: 'Matenimiento de Regiones' }
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TipocompersonaEditRoutingModule { }
