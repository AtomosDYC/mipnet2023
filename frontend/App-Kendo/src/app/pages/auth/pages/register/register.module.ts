import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {  FormsModule } from '@angular/forms';

import { RegisterRoutingModule } from './register-routing.module';
import { RegisterComponent } from './register.component';
import { GridModule } from '@progress/kendo-angular-grid';
import { ButtonModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';




@NgModule({
  declarations: [
    RegisterComponent
  ],
  imports: [
    CommonModule,
    RegisterRoutingModule ,
    FormsModule,
    GridModule,
    ButtonModule,
    CardModule,
    FormsModule,

  ],
  exports: [
    RegisterComponent
  ]
})
export class RegisterModule { }
