import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../../../guards/auth/auth.guard';

const routes: Routes = [
  {
    path: 'list',
    loadChildren: () => import('./pages/saludo-list/saludo-list.module').then(m=>m.SaludoListModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'nuevo',
    loadChildren: () => import('./pages/saludo-nuevo/saludo-nuevo.module').then(m=>m.SaludoNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'edit',
    loadChildren: () => import('./pages/saludo-nuevo/saludo-nuevo.module').then(m=>m.SaludoNuevoModule),
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
export class SaludoRoutingModule { }
