import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';
import { GridModule } from '@progress/kendo-angular-grid';
import { ButtonModule, ButtonsModule } from '@progress/kendo-angular-buttons';
import { CardModule, LayoutModule } from '@progress/kendo-angular-layout';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';

@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    CommonModule,
    LoginRoutingModule,
    GridModule,
    ButtonModule,
    CardModule,
    ReactiveFormsModule,
    FormsModule,
    ReactiveFormsModule,
    DateInputsModule,
    InputsModule,
    LayoutModule,
    LabelModule,
    
    ButtonsModule,
  ],
  exports: [
    LoginComponent
  ]
})
export class LoginModule { }
