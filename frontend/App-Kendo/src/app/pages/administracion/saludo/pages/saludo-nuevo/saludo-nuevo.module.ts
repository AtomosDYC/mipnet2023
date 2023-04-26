import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SaludoNuevoRoutingModule } from './saludo-nuevo-routing.module';
import { SaludoNuevoComponent } from './saludo-nuevo.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';


@NgModule({
  declarations: [
    SaludoNuevoComponent
  ],
  imports: [
    CommonModule,
    SaludoNuevoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
  ]
})
export class SaludoNuevoModule { }
