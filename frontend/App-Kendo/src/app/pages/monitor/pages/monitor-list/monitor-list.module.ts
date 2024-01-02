import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MonitorListRoutingModule } from './monitor-list-routing.module';
import { MonitorListComponent } from './monitor-list.component';
import { ButtonGroupModule, ButtonModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { GridModule, ExcelModule } from "@progress/kendo-angular-grid";
import { InputsModule, SharedModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

import { PDFModule } from '@progress/kendo-angular-scheduler';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    MonitorListComponent
  ],
  imports: [
    CommonModule,
    MonitorListRoutingModule,
    ButtonModule,
    CardModule,
    GridModule,
    SharedModule,
    InputsModule,
    LabelModule,
    ButtonGroupModule,
    DropDownsModule,
    ReactiveFormsModule,
    FormsModule,
    ExcelModule,
    PDFModule,
  ]
})
export class MonitorListModule { }
