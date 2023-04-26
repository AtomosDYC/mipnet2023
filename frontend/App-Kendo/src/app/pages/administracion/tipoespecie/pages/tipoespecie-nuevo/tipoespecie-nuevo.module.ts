import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipoespecieNuevoRoutingModule } from './tipoespecie-nuevo-routing.module';
import { TipoespecieNuevoComponent } from './tipoespecie-nuevo.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';


@NgModule({
  declarations: [
    TipoespecieNuevoComponent
  ],
  imports: [
    CommonModule,
    TipoespecieNuevoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
  ]
})
export class TipoespecieNuevoModule { }
