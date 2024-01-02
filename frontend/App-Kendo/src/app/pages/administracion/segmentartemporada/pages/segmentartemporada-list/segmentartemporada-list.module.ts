import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SegmentartemporadaListComponent } from './segmentartemporada-list.component';

import { SegmentartemporadaListRoutingModule } from './segmentartemporada-list-routing.module';
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
  
    SegmentartemporadaListComponent
  ],
  imports: [
    CommonModule,
    SegmentartemporadaListRoutingModule,
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
export class SegmentartemporadaListModule { }
