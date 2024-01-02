import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SegmentartemporadaNuevoComponent } from './segmentartemporada-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:SegmentartemporadaNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo de Parametro' }
  },
  {
    path:':id',
    component:SegmentartemporadaNuevoComponent,
    data: { titulo: 'Matenimiento de Tipo Parametro' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SegmentartemporadaNuevoRoutingModule { }
