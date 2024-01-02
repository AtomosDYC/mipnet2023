import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonasDatosgeneralesComponent } from './personas-datosgenerales.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { ComboBoxModule, DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { RutModule } from 'rut-chileno';


@NgModule({
  declarations: [
    PersonasDatosgeneralesComponent
  ],
  exports: [
    PersonasDatosgeneralesComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
    DropDownsModule,
    ComboBoxModule,
    LayoutModule,
    RutModule
  ]
})
export class PersonasDatosgeneralesModule { }
