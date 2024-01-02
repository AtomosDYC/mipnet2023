import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuarioEditRoutingModule } from './usuario-edit-routing.module';
import { UsuarioEditComponent } from './usuario-edit.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { ComboBoxModule, DropDownsModule } from '@progress/kendo-angular-dropdowns';


@NgModule({
  declarations: [
    UsuarioEditComponent
  ],
  imports: [
    CommonModule,
    UsuarioEditRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
    DropDownsModule,
    ComboBoxModule,
  ]
})
export class UsuarioEditModule { }
