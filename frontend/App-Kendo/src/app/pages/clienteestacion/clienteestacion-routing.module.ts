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
