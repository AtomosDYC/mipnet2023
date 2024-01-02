import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonasDatosaccesoComponent } from './personas-datosacceso.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { StoreModule } from '@ngrx/store';
import { effects, reducers } from './store';
import { EffectsModule } from '@ngrx/effects';



@NgModule({
  declarations: [
    PersonasDatosaccesoComponent
  ],
  exports:[
    PersonasDatosaccesoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
    StoreModule.forFeature('personaacceso', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class PersonasDatosaccesoModule { }
