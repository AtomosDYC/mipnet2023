import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ComunaNuevoComponent } from './comuna-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:ComunaNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo de Comunas' }
  },
  {
    path:':id',
    component:ComunaNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo Comunas' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ComunaNuevoRoutingModule { }
