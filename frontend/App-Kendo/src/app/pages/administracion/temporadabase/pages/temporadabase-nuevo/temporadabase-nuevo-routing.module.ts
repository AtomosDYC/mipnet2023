import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TemporadabaseNuevoComponent } from './temporadabase-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:TemporadabaseNuevoComponent,
    data: { titulo: 'Mantenimiento de Temporada Base' }
  },
  {
    path:':id',
    component:TemporadabaseNuevoComponent,
    data: { titulo: 'Mantenimiento de Temporada Base' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TemporadabaseNuevoRoutingModule { }
