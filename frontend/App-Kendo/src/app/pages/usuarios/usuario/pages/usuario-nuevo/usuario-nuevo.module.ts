import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuarioNuevoRoutingModule } from './usuario-nuevo-routing.module';
import { UsuarioNuevoComponent } from './usuario-nuevo.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';

@NgModule({
  declarations: [
    UsuarioNuevoComponent
  ],
  imports: [
    CommonModule,
    UsuarioNuevoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
  ]
})
export class UsuarioNuevoModule { }
