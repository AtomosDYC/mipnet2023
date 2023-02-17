import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../../guards/auth/auth.guard';

const routes: Routes = [
  {
    path: 'nuevo',
    loadChildren: () => import('./inmueble-nuevo/inmueble-nuevo.module').then(m=>m.InmuebleNuevoModule)
  },
  {
    path: 'list',
    loadChildren: () => import('./inmueble-list/inmueble-list.module').then(m=>m.InmuebleListModule)
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
export class InmuebleRoutingModule { }
