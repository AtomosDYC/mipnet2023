import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MonitorNuevoComponent } from './monitor-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:MonitorNuevoComponent,
    data: { titulo: 'Matenimiento de Especies' }
  },
  {
    path:':id',
    component:MonitorNuevoComponent,
    data: { titulo: 'Matenimiento de Especies' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MonitorNuevoRoutingModule { }
