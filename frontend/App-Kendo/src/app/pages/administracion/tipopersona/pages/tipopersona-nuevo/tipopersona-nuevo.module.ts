import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipopersonaNuevoRoutingModule } from './tipopersona-nuevo-routing.module';
import { TipopersonaNuevoComponent } from './tipopersona-nuevo.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';

@NgModule({
  declarations: [
    TipopersonaNuevoComponent
  ],
  imports: [
    CommonModule,
    TipopersonaNuevoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
  ]
})
export class TipopersonaNuevoModule { }
