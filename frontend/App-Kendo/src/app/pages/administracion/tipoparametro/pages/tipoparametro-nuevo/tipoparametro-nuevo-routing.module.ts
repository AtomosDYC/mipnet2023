import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TipocompersonaNuevoComponent } from '../../../tipocomunicacionpersona/pages/tipocompersona-nuevo/tipocompersona-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:TipocompersonaNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo de Parametro' }
  },
  {
    path:':id',
    component:TipocompersonaNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo Parametro' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TipoparametroNuevoRoutingModule { }
