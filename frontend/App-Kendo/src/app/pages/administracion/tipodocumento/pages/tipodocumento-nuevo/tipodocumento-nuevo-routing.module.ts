import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TipodocumentoNuevoComponent } from './tipodocumento-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:TipodocumentoNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo de Documento' }
  },
  {
    path:':id',
    component:TipodocumentoNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo de Documento' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TipodocumentoNuevoRoutingModule { }
