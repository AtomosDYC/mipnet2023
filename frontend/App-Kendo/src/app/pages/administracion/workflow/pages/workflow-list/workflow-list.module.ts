import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WorkflowListRoutingModule } from './workflow-list-routing.module';
import { WorkflowListComponent } from './workflow-list.component';
import { ButtonModule, ButtonGroupModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { GridModule, ExcelModule, PDFModule } from '@progress/kendo-angular-grid';
import { SharedModule, InputsModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

import { TreeListModule } from '@progress/kendo-angular-treelist';


@NgModule({
  declarations: [
    WorkflowListComponent
  ],
  imports: [
    CommonModule,
    WorkflowListRoutingModule,
    ButtonModule,
    CardModule,
    GridModule,
    SharedModule,
    InputsModule,
    LabelModule,
    ButtonGroupModule,
    DropDownsModule,
    
    ExcelModule,
    PDFModule,
    TreeListModule
  ]
})
export class WorkflowListModule { }
