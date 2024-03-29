import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UnauthGuard } from '../../guards/unauth/unauth.guard';


const routes: Routes = [
  {
    path:'login',
    loadChildren:
      () => import('./pages/login/login.module').then(m=> m.LoginModule),
      canActivate: [UnauthGuard],
  },
  {
    path:'registro',
    loadChildren:
      () => import('./pages/register/register.module').then(m=> m.RegisterModule),
      canActivate: [UnauthGuard],
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
