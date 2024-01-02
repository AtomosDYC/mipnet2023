import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonasListComponent } from './personas-list.component';

const routes: Routes = [
  {
    path:'',
    component:PersonasListComponent,
    data: { titulo: 'Matenimiento de Especies' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PersonasListRoutingModule { }
