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
  },
  {
    path:'forgotpassword',
    loadChildren:
      () => import('./pages/forgot-password/forgot-password.module').then(m=> m.ForgotPasswordModule),
      canActivate: [UnauthGuard],
  },
  {
    path:'resetpassword',
    loadChildren:
      () => import('./pages/reset-password/reset-password.module').then(m=> m.ResetPasswordModule),
      canActivate: [UnauthGuard],
  },
  {
    path:'emailconfirmation',
    loadChildren:
      () => import('./pages/email-confirmation/email-confirmation.module').then(m=> m.ResetPasswordModule),
      canActivate: [UnauthGuard],
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
