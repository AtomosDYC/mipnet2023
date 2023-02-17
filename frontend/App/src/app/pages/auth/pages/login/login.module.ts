import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';

import {
  FormModule,
  GridModule,
  ButtonModule,
  CardModule,
} from '@coreui/angular-pro';

import { IconModule } from '@coreui/icons-angular';
import { SpinerModule } from '../../../../shared/indicators/spiner/spiner.module';

@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    CommonModule,
    LoginRoutingModule,
    FormModule,
    GridModule,
    ButtonModule,
    CardModule,
    IconModule,
    FormsModule,
    SpinerModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [
    LoginComponent
  ]
})
export class LoginModule { }
