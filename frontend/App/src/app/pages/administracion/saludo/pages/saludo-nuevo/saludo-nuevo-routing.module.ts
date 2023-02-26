import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SaludoNuevoComponent } from './saludo-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:SaludoNuevoComponent,
    data: { titulo: 'Matenimiento de Regiones' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SaludoNuevoRoutingModule { }
