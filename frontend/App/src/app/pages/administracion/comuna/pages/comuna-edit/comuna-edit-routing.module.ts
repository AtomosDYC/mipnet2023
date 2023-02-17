import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ComunaEditComponent } from './comuna-edit.component';

const routes: Routes = [
  {
    path:':id',
    component:ComunaEditComponent,
    data: { titulo: 'Matenimiento de Comunas' }
  },
  {
    path: '',
    component:ComunaEditComponent,
    data: { titulo: 'Matenimiento de Comunas' }
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ComunaEditRoutingModule { }
