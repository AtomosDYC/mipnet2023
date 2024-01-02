import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EspecieListRoutingModule } from './especie-list-routing.module';
import { EspecieListComponent } from './especie-list.component';
import { ButtonGroupModule, ButtonModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { GridModule } from '@progress/kendo-angular-grid';
import { InputsModule, SharedModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

import { ExcelModule } from '@progress/kendo-angular-treelist';
import { PDFModule } from '@progress/kendo-angular-scheduler';



@NgModule({
  declarations: [
    EspecieListComponent
  ],
  imports: [
    CommonModule,
    EspecieListRoutingModule,
    ButtonModule,
    CardModule,
    GridModule,
    SharedModule,
    InputsModule,
    LabelModule,
    ButtonGroupModule,
    DropDownsModule,
    
    ExcelModule,
    PDFModule
  ]
})
export class EspecieListModule { }
