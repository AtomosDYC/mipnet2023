import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PlantillaNuevoComponent } from './plantilla-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:PlantillaNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo de Personas' }
  },
  {
    path:':id',
    component:PlantillaNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo Personas' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PlantillaNuevoRoutingModule { }
