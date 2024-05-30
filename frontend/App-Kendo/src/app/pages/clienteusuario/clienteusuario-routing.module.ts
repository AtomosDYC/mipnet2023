import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteusuarioListModule } from './pages/clienteusuario-list/clienteusuario-list.module';
import { AuthGuard } from 'src/app/guards/auth/auth.guard';

const routes: Routes = [
  {
    path: 'list',
    loadChildren: () => import('./pages/clienteusuario-list/clienteusuario-list.module').then(m=>m.ClienteusuarioListModule),
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
export class ClienteusuarioRoutingModule { }
