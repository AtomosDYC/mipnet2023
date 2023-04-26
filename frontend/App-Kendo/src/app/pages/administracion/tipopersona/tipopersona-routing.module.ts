import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../../../guards/auth/auth.guard';

const routes: Routes = [
  {
    path: 'list',
    loadChildren: () => import('./pages/tipopersona-list/tipopersona-list.module').then(m=>m.TipopersonaListModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'nuevo',
    loadChildren: () => import('./pages/tipopersona-nuevo/tipopersona-nuevo.module').then(m=>m.TipopersonaNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'edit',
    loadChildren: () => import('./pages/tipopersona-nuevo/tipopersona-nuevo.module').then(m=>m.TipopersonaNuevoModule),
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
export class TipopersonaRoutingModule { }
