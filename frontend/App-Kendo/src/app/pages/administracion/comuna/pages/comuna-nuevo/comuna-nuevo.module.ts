import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ComunaNuevoRoutingModule } from './comuna-nuevo-routing.module';
import { ComunaNuevoComponent } from './comuna-nuevo.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { ComboBoxModule, DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { IconsModule } from '@progress/kendo-angular-icons';
import { LayoutModule } from '@progress/kendo-angular-layout';




@NgModule({
  declarations: [
    ComunaNuevoComponent
  ],
  imports: [
    CommonModule,
    ComunaNuevoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
    DropDownsModule,
    ComboBoxModule,
    LayoutModule,
    IconsModule,
  
  ]
})
export class ComunaNuevoModule { }
