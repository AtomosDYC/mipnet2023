import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TemporadabaseNuevoRoutingModule } from './temporadabase-nuevo-routing.module';
import { TemporadabaseNuevoComponent } from './temporadabase-nuevo.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CheckBoxModule, InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';


@NgModule({
  declarations: [
    TemporadabaseNuevoComponent
  ],
  imports: [
    CommonModule,
    TemporadabaseNuevoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
    CheckBoxModule
  ]
})
export class TemporadabaseNuevoModule { }
