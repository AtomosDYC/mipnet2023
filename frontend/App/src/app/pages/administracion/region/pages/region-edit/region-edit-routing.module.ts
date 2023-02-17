import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegionEditComponent } from './region-edit.component';
import { RegionListComponent } from '../region-list/region-list.component';

const routes: Routes = [
  {
    path:':id',
    component:RegionEditComponent,
    data: { titulo: 'Matenimiento de Regiones' }
  },
  {
    path: '',
    component:RegionEditComponent,
    data: { titulo: 'Matenimiento de Regiones' }
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RegionEditRoutingModule { }
