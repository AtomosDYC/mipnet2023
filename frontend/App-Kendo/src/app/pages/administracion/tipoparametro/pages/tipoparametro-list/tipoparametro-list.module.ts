import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipoparametroListRoutingModule } from './tipoparametro-list-routing.module';
import { TipoparametroListComponent } from './tipoparametro-list.component';
import { ButtonModule, ButtonGroupModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { GridModule, ExcelModule, PDFModule } from '@progress/kendo-angular-grid';
import { SharedModule, InputsModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';



@NgModule({
  declarations: [
    TipoparametroListComponent
  ],
  imports: [
    CommonModule,
    TipoparametroListRoutingModule,
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
export class TipoparametroListModule { }
