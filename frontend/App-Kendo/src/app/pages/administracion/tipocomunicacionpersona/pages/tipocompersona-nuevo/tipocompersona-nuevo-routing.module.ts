import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TipocompersonaNuevoComponent } from './tipocompersona-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:TipocompersonaNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo de Personas' }
  },
  {
    path:':id',
    component:TipocompersonaNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo Personas' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TipocompersonaNuevoRoutingModule { }
