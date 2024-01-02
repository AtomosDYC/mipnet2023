import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonasContenedorComponent } from './personas-contenedor.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { ComboBoxModule, DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { LayoutModule } from '@progress/kendo-angular-layout';

import { PersonasDatosaccesoComponent } from '../personas-datosacceso/personas-datosacceso.component';
import { PersonasDatosgeneralesModule } from '../personas-datosgenerales/personas-datosgenerales.module';
import { PersonasDatoscomunicacionModule } from '../personas-datoscomunicacion/personas-datoscomunicacion.module';
import { PersonasDatosaccesoModule } from '../personas-datosacceso/personas-datosacceso.module';



@NgModule({
  declarations: [
    PersonasContenedorComponent
  ],
  exports: [
    PersonasContenedorComponent
  ],
  imports: [
    CommonModule,
    PersonasDatosgeneralesModule,
    PersonasDatoscomunicacionModule,
    PersonasDatosaccesoModule
  ]
})
export class PersonasContenedorModule { }
