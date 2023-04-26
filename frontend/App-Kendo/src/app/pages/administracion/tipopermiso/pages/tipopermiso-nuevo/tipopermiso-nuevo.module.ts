import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipopermisoNuevoRoutingModule } from './tipopermiso-nuevo-routing.module';
import { TipopermisoNuevoComponent } from './tipopermiso-nuevo.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';


@NgModule({
  declarations: [
    TipopermisoNuevoComponent
  ],
  imports: [
    CommonModule,
    TipopermisoNuevoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
  ]
})
export class TipopermisoNuevoModule { }
