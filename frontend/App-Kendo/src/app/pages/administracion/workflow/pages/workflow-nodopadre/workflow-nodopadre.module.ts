import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WorkflowNodopadreComponent } from './workflow-nodopadre.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { DropDownsModule, ComboBoxModule } from '@progress/kendo-angular-dropdowns';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { IconsModule } from '@progress/kendo-angular-icons';


@NgModule({
  declarations: [
    WorkflowNodopadreComponent
  ],
  exports: [
    WorkflowNodopadreComponent
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
    IconsModule,
  ]
})
export class WorkflowNodopadreModule { }
