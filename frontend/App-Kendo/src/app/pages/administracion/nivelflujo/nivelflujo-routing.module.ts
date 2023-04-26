import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../../../guards/auth/auth.guard';

const routes: Routes = [
  {
    path: 'list',
    loadChildren: () => import('./pages/nivelflujo-list/nivelflujo-list.module').then(m=>m.NivelflujoListModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'nuevo',
    loadChildren: () => import('./pages/nivelflujo-nuevo/nivelflujo-nuevo.module').then(m=>m.NivelflujoNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'edit',
    loadChildren: () => import('./pages/nivelflujo-nuevo/nivelflujo-nuevo.module').then(m=>m.NivelflujoNuevoModule),
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
export class NivelflujoRoutingModule { }
