import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EstadodanioNuevoRoutingModule } from './estadodanio-nuevo-routing.module';
import { EstadodanioNuevoComponent } from './estadodanio-nuevo.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { DropDownsModule, ComboBoxModule } from '@progress/kendo-angular-dropdowns';
import { LayoutModule } from '@progress/kendo-angular-layout';



@NgModule({
  declarations: [
    EstadodanioNuevoComponent
  ],
  imports: [
    CommonModule,
    EstadodanioNuevoRoutingModule,
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
export class EstadodanioNuevoModule { }
