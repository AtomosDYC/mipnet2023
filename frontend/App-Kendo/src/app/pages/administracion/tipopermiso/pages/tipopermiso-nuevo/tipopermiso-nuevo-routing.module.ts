import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TipopermisoNuevoComponent } from './tipopermiso-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:TipopermisoNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo de Permiso' }
  },
  {
    path:':id',
    component:TipopermisoNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo Permiso' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TipopermisoNuevoRoutingModule { }
