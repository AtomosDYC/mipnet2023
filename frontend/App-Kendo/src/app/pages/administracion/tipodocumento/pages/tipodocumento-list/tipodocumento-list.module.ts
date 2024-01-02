import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipodocumentoListRoutingModule } from './tipodocumento-list-routing.module';
import { TipodocumentoListComponent } from './tipodocumento-list.component';
import { ButtonModule, ButtonGroupModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { GridModule, ExcelModule, PDFModule } from '@progress/kendo-angular-grid';
import { SharedModule, InputsModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';



@NgModule({
  declarations: [
    TipodocumentoListComponent
  ],
  imports: [
    CommonModule,
    TipodocumentoListRoutingModule,
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
export class TipodocumentoListModule { }
