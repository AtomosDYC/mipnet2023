import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SegmentartemporadaListComponent } from './segmentartemporada-list.component';

const routes: Routes = [
  {
    path:'',
    component:SegmentartemporadaListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SegmentartemporadaListRoutingModule { }
