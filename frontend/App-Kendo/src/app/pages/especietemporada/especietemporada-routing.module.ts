import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EspecietemporadaListModule } from './pages/especietemporada-list/especietemporada-list.module';
import { AuthGuard } from 'src/app/guards/auth/auth.guard';

const routes: Routes = [
  {
    path: 'list',
    loadChildren: () => import('./pages/especietemporada-list/especietemporada-list.module').then(m=>m.EspecietemporadaListModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'nuevo',
    loadChildren: () => import('./pages/especietemporada-nuevo/especietemporada-nuevo.module').then(m=>m.EspecietemporadaNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'edit',
    loadChildren: () => import('./pages/especietemporada-nuevo/especietemporada-nuevo.module').then(m=>m.EspecietemporadaNuevoModule),
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
export class EspecietemporadaRoutingModule { }
