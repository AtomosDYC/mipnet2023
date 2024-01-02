import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TemporadaNuevoRoutingModule } from './temporada-nuevo-routing.module';
import { TemporadaNuevoComponent } from './temporada-nuevo.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CheckBoxModule, InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { ComboBoxModule, DropDownsModule } from '@progress/kendo-angular-dropdowns';


@NgModule({
  declarations: [
    TemporadaNuevoComponent
  ],
  imports: [
    CommonModule,
    TemporadaNuevoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
    CheckBoxModule,
    DropDownsModule,
    ComboBoxModule,
  ]
})
export class TemporadaNuevoModule { }
