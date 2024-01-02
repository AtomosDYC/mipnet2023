import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TemporadaNuevoComponent } from './temporada-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:TemporadaNuevoComponent,
    data: { titulo: 'Mantenimiento de Temporada Base' }
  },
  {
    path:':id',
    component:TemporadaNuevoComponent,
    data: { titulo: 'Mantenimiento de Temporada Base' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TemporadaNuevoRoutingModule { }
