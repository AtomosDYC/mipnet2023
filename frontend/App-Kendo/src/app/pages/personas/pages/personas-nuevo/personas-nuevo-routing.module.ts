import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonasNuevoComponent } from './personas-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:PersonasNuevoComponent,
    data: { titulo: 'Matenimiento de Especies' }
  },
  {
    path:':id',
    component:PersonasNuevoComponent,
    data: { titulo: 'Matenimiento de Especies' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PersonasNuevoRoutingModule { }
