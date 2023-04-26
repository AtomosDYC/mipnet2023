import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipodocumentoNuevoRoutingModule } from './tipodocumento-nuevo-routing.module';
import { TipodocumentoNuevoComponent } from './tipodocumento-nuevo.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';



@NgModule({
  declarations: [
    TipodocumentoNuevoComponent
  ],
  imports: [
    CommonModule,
    TipodocumentoNuevoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
  ]
})
export class TipodocumentoNuevoModule { }
