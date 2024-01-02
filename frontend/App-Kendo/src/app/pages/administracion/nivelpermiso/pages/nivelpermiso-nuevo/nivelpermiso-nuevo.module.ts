import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NivelpermisoNuevoRoutingModule } from './nivelpermiso-nuevo-routing.module';
import { NivelpermisoNuevoComponent } from './nivelpermiso-nuevo.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { DropDownsModule, ComboBoxModule } from '@progress/kendo-angular-dropdowns';
import { LayoutModule } from '@progress/kendo-angular-layout';



@NgModule({
  declarations: [
    NivelpermisoNuevoComponent
  ],
  imports: [
    CommonModule,
    NivelpermisoNuevoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
    DropDownsModule,
    ComboBoxModule,
    LayoutModule,
    
  ]
})
export class NivelpermisoNuevoModule { }
