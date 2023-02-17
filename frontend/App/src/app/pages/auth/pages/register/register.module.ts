import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {  FormsModule } from '@angular/forms';

import { RegisterRoutingModule } from './register-routing.module';
import { RegisterComponent } from './register.component';

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
    RegisterComponent
  ],
  imports: [
    CommonModule,
    RegisterRoutingModule,
    FormModule,
    GridModule,
    ButtonModule,
    CardModule,
    IconModule,
    FormsModule,
    SpinerModule,

  ],
  exports: [
    RegisterComponent
  ]
})
export class RegisterModule { }
