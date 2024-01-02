import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EspecietemporadaListRoutingModule } from './especietemporada-list-routing.module';
import { ButtonGroupModule, ButtonModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { GridModule } from '@progress/kendo-angular-grid';
import { InputsModule, SharedModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ExcelModule } from '@progress/kendo-angular-treelist';

import { EspecietemporadaListComponent } from './especietemporada-list.component';
import { PDFModule } from '@progress/kendo-angular-grid';

@NgModule({
  declarations: [
    EspecietemporadaListComponent
  ],
  imports: [
    CommonModule,
    EspecietemporadaListRoutingModule,
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
export class EspecietemporadaListModule { }
