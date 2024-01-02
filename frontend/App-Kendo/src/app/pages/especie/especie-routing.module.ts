import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EspecieListModule } from './pages/especie-list/especie-list.module';
import { AuthGuard } from 'src/app/guards/auth/auth.guard';

const routes: Routes = [
  {
    path: 'list',
    loadChildren: () => import('./pages/especie-list/especie-list.module').then(m=>m.EspecieListModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'nuevo',
    loadChildren: () => import('./pages/especie-nuevo/especie-nuevo.module').then(m=>m.EspecieNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'datosgenerales',
    loadChildren: () => import('./pages/especie-nuevo/especie-nuevo.module').then(m=>m.EspecieNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'unirespecies',
    loadChildren: () => import('./pages/especie-nuevo/especie-nuevo.module').then(m=>m.EspecieNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'tiposdatos',
    loadChildren: () => import('./pages/especie-nuevo/especie-nuevo.module').then(m=>m.EspecieNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'umbrales',
    loadChildren: () => import('./pages/especie-nuevo/especie-nuevo.module').then(m=>m.EspecieNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'reglasgrafico',
    loadChildren: () => import('./pages/especie-nuevo/especie-nuevo.module').then(m=>m.EspecieNuevoModule),
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
export class EspecieRoutingModule { }
