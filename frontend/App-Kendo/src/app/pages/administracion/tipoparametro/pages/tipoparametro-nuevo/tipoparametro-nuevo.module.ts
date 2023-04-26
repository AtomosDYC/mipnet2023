import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { TipoparametroNuevoRoutingModule } from './tipoparametro-nuevo-routing.module';
import { TipoparametroNuevoComponent } from './tipoparametro-nuevo.component';




@NgModule({
  declarations: [
    TipoparametroNuevoComponent
  ],
  imports: [
    CommonModule,
    TipoparametroNuevoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,

  ]
})
export class TipoparametroNuevoModule { }
