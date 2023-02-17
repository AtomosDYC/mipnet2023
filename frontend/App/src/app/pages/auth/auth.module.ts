import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { RegisterComponent } from './pages/register/register.component';
import { AuthRoutingModule } from '../auth/auth-routing.module';
import { LoginModule } from './pages/login/login.module';
import { RegisterModule } from './pages/register/register.module';

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    RouterModule,
    AuthRoutingModule,
    LoginModule,
    RegisterModule
  ],
  exports: [
  ]
})
export class AuthModule { }
