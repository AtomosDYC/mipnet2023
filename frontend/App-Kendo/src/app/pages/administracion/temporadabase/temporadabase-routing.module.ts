import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TemporadabaseListModule } from './pages/temporadabase-list/temporadabase-list.module';
import { AuthGuard } from 'src/app/guards/auth/auth.guard';

const routes: Routes = [
  {
    path: 'list',
    loadChildren: () => import('./pages/temporadabase-list/temporadabase-list.module').then(m=>m.TemporadabaseListModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'nuevo',
    loadChildren: () => import('./pages/temporadabase-nuevo/temporadabase-nuevo.module').then(m=>m.TemporadabaseNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'edit',
    loadChildren: () => import('./pages/temporadabase-nuevo/temporadabase-nuevo.module').then(m=>m.TemporadabaseNuevoModule),
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
export class TemporadabaseRoutingModule { }
