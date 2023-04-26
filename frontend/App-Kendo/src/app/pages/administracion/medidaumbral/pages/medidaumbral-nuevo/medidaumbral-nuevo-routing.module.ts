import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MedidaumbralNuevoComponent } from './medidaumbral-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:MedidaumbralNuevoComponent,
    data: { titulo: 'Matenimiento de Umbrales de Especie' }
  },
  {
    path:':id',
    component:MedidaumbralNuevoComponent,
    data: { titulo: 'Matenimiento de Umbrales de Especie' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MedidaumbralNuevoRoutingModule { }
