import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../../../guards/auth/auth.guard';

const routes: Routes = [
  {
    path: 'nuevo',
    loadChildren: () => import('./pages/defaultuser-list/defaultuser-list.module').then(m=>m.DefaultuserListModule),
    canActivate: [AuthGuard]
  },
  {
    path: '**',
    pathMatch: 'full',
    redirectTo: 'nuevo'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DefaultuserRoutingModule { }
