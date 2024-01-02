import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/guards/auth/auth.guard';

const routes: Routes = [
  {
    path: 'list',
    loadChildren: () => import('./pages/personas-list/personas-list.module').then(m=>m.PersonasListModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'nuevo',
    loadChildren: () => import('./pages/personas-nuevo/personas-nuevo.module').then(m=>m.PersonasNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'datosgenerales',
    loadChildren: () => import('./pages/personas-nuevo/personas-nuevo.module').then(m=>m.PersonasNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'datoscomunicacion',
    loadChildren: () => import('./pages/personas-nuevo/personas-nuevo.module').then(m=>m.PersonasNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'datosacceso',
    loadChildren: () => import('./pages/personas-nuevo/personas-nuevo.module').then(m=>m.PersonasNuevoModule),
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PersonasRoutingModule { }
