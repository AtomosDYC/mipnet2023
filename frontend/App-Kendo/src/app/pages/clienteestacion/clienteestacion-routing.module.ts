import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteestacionListModule } from './pages/clienteestacion-list/clienteestacion-list.module';
import { AuthGuard } from 'src/app/guards/auth/auth.guard';

const routes: Routes = [
  {
    path: 'list',
    loadChildren: () => import('./pages/clienteestacion-list/clienteestacion-list.module').then(m=>m.ClienteestacionListModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'nuevo',
    loadChildren: () => import('./pages/clienteestacion-nuevo/clienteestacion-nuevo.module').then(m=>m.ClienteestacionNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'datosgenerales',
    loadChildren: () => import('./pages/clienteestacion-nuevo/clienteestacion-nuevo.module').then(m=>m.ClienteestacionNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'datoscomunicacion',
    loadChildren: () => import('./pages/clienteestacion-nuevo/clienteestacion-nuevo.module').then(m=>m.ClienteestacionNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'datoscontacto',
    loadChildren: () => import('./pages/clienteestacion-nuevo/clienteestacion-nuevo.module').then(m=>m.ClienteestacionNuevoModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'estaciones',
    loadChildren: () => import('./pages/clienteestacion-nuevo/clienteestacion-nuevo.module').then(m=>m.ClienteestacionNuevoModule),
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
export class ClienteestacionRoutingModule { }
