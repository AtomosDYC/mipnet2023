import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NivelpermisoNuevoComponent } from './nivelpermiso-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:NivelpermisoNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo de Comunas' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NivelpermisoNuevoRoutingModule { }
