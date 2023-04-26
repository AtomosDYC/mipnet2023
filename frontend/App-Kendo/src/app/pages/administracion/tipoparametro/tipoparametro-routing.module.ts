import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../../../guards/auth/auth.guard';

const routes: Routes = [
  {
    path: 'list',
    loadChildren: () => import('./pages/tipoparametro-list/tipoparametro-list.module').then(m=>m.TipoparametroListModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'nuevo',
    loadChildren: () => import('./pages/tipoparametro-nuevo/tipoparametro-nuevo.module').then(m=>m.TipoparametroNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'edit',
    loadChildren: () => import('./pages/tipoparametro-nuevo/tipoparametro-nuevo.module').then(m=>m.TipoparametroNuevoModule),
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
export class TipoparametroRoutingModule { }
