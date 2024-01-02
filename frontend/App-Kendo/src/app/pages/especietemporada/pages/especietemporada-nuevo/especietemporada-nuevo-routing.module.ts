import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EspecietemporadaListComponent } from '../especietemporada-list/especietemporada-list.component';
import { EspecietemporadaNuevoComponent } from './especietemporada-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:EspecietemporadaNuevoComponent,
    data: { titulo: 'Mantenimiento de Temporada de especie' }
  },
  {
    path:':id',
    component:EspecietemporadaNuevoComponent,
    data: { titulo: 'Mantenimiento de Temporada de especie' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EspecietemporadaNuevoRoutingModule { }
