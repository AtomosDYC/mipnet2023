import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipoflujoNuevoRoutingModule } from './tipoflujo-nuevo-routing.module';
import { TipoflujoNuevoComponent } from './tipoflujo-nuevo.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';


@NgModule({
  declarations: [
    TipoflujoNuevoComponent
  ],
  imports: [
    CommonModule,
    TipoflujoNuevoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
  ]
})
export class TipoflujoNuevoModule { }
