import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlantillaDatosgeneralesComponent } from './plantilla-datosgenerales.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';



@NgModule({
  declarations: [
    PlantillaDatosgeneralesComponent
  ],
  exports: [
    PlantillaDatosgeneralesComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
  ]
})
export class PlantillaDatosgeneralesModule { }
