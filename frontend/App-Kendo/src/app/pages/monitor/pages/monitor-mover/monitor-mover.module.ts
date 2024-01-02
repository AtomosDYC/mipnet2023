import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MonitorMoverComponent } from './monitor-mover.component';
import { ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { ComboBoxModule, DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { LayoutModule } from '@progress/kendo-angular-layout';




@NgModule({
  declarations: [
    MonitorMoverComponent
  ],
  exports: [
    MonitorMoverComponent
  ],
  imports: [
    CommonModule,
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
export class MonitorMoverModule { }
