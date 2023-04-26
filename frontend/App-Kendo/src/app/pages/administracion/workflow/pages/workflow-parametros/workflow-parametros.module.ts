import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WorkflowParametrosComponent } from './workflow-parametros.component';
import { ButtonModule, ButtonGroupModule, ButtonsModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { GridModule, ExcelModule, PDFModule } from '@progress/kendo-angular-grid';
import { SharedModule, InputsModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { IconsModule } from '@progress/kendo-angular-icons';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';

@NgModule({
  declarations: [
    WorkflowParametrosComponent
  ],
  exports: [
    WorkflowParametrosComponent
  ],
  imports: [
    CommonModule,
    ButtonModule,
    CardModule,
    GridModule,
    SharedModule,
    InputsModule,
    LabelModule,
    ButtonGroupModule,
    DropDownsModule,
    IconsModule,
    ExcelModule,
    PDFModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    
    StoreModule.forFeature('workflowparametro', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class WorkflowParametrosModule { }
