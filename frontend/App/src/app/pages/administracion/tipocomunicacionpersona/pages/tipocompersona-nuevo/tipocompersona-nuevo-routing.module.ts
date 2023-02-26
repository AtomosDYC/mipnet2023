import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TipocompersonaNuevoComponent } from './tipocompersona-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:TipocompersonaNuevoComponent,
    data: { titulo: 'Nuevo Tipo de Comunicacion para personas' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TipocompersonaNuevoRoutingModule { }
