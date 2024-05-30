import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MonitoreoListComponent } from './monitoreo-list.component';

const routes: Routes = [
  {
    path:'',
    component:MonitoreoListComponent,
    data: { titulo: 'listado de monitoreos' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MonitoreoListRoutingModule { }
