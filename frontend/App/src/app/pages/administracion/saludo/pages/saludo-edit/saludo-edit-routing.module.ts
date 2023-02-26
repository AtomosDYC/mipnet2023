import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SaludoEditComponent } from './saludo-edit.component';

const routes: Routes = [
  {
    path:':id',
    component:SaludoEditComponent,
    data: { titulo: 'Matenimiento de Regiones' }
  },
  {
    path: '',
    component:SaludoEditComponent,
    data: { titulo: 'Matenimiento de Regiones' }
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SaludoEditRoutingModule { }
