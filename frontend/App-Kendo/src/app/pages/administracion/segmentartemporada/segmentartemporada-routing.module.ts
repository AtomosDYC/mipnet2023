import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SegmentartemporadaModule } from './segmentartemporada.module';
import { AuthGuard } from 'src/app/guards/auth/auth.guard';
import { SegmentartemporadaListComponent } from './pages/segmentartemporada-list/segmentartemporada-list.component';
import { SegmentartemporadaListModule } from './pages/segmentartemporada-list/segmentartemporada-list.module';
import { SegmentartemporadaNuevoModule } from './pages/segmentartemporada-nuevo/segmentartemporada-nuevo.module';

const routes: Routes = [
  {
    path: 'list',
    loadChildren: () => import('./pages/segmentartemporada-list/segmentartemporada-list.module').then(m=>m.SegmentartemporadaListModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'nuevo',
    loadChildren: () => import('./pages/segmentartemporada-nuevo/segmentartemporada-nuevo.module').then(m=>m.SegmentartemporadaNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'edit',
    loadChildren: () => import('./pages/segmentartemporada-nuevo/segmentartemporada-nuevo.module').then(m=>m.SegmentartemporadaNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: '**',
    pathMatch: 'full',
    redirectTo: 'list'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SegmentartemporadaRoutingModule { }
