import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TipopercomunicacionListComponent } from './tipopercomunicacion-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule, SharedModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule, ButtonGroupModule } from '@progress/kendo-angular-buttons';
import { LayoutModule, CardModule } from '@progress/kendo-angular-layout';
import { GridModule, ExcelModule, PDFModule } from '@progress/kendo-angular-grid';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { IconsModule } from '@progress/kendo-angular-icons';



@NgModule({
  declarations: [
    TipopercomunicacionListComponent
  ],
  exports: [
    TipopercomunicacionListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
    LayoutModule,
    CardModule,
    GridModule,
    SharedModule,
    ButtonGroupModule,
    DropDownsModule,
    IconsModule,
    ExcelModule,
    PDFModule
  ]
})
export class TipopercomunicacionListModule { }
