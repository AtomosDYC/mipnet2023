import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegionNuevoComponent } from './region-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:RegionNuevoComponent,
    data: { titulo: 'Matenimiento de Regiones' }
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RegionNuevoRoutingModule { }
