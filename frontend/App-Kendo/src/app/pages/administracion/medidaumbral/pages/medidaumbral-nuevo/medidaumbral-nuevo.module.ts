import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MedidaumbralNuevoRoutingModule } from './medidaumbral-nuevo-routing.module';
import { MedidaumbralNuevoComponent } from './medidaumbral-nuevo.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';


@NgModule({
  declarations: [
    MedidaumbralNuevoComponent
  ],
  imports: [
    CommonModule,
    MedidaumbralNuevoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
  ]
})
export class MedidaumbralNuevoModule { }
