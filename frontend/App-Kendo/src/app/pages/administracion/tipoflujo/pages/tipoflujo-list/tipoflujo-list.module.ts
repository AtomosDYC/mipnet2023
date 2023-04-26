import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipoflujoListRoutingModule } from './tipoflujo-list-routing.module';
import { TipoflujoListComponent } from './tipoflujo-list.component';
import { ButtonModule, ButtonGroupModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { GridModule, ExcelModule, PDFModule } from '@progress/kendo-angular-grid';
import { SharedModule, InputsModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { IconsModule } from '@progress/kendo-angular-icons';


@NgModule({
  declarations: [
    TipoflujoListComponent
  ],
  imports: [
    CommonModule,
    TipoflujoListRoutingModule,
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
    PDFModule
  ]
})
export class TipoflujoListModule { }
