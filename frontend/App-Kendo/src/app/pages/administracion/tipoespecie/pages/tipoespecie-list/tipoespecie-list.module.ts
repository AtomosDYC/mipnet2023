import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipoespecieListRoutingModule } from './tipoespecie-list-routing.module';
import { TipoespecieListComponent } from './tipoespecie-list.component';
import { ButtonModule, ButtonGroupModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { GridModule, ExcelModule, PDFModule } from '@progress/kendo-angular-grid';
import { SharedModule, InputsModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';



@NgModule({
  declarations: [
    TipoespecieListComponent
  ],
  imports: [
    CommonModule,
    TipoespecieListRoutingModule,
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
export class TipoespecieListModule { }
