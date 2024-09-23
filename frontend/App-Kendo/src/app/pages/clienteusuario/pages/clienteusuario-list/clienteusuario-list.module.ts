import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClienteusuarioListRoutingModule } from './clienteusuario-list-routing.module';
import { ClienteusuarioListComponent } from './clienteusuario-list.component';
import { ButtonGroupModule, ButtonModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { GridModule } from '@progress/kendo-angular-grid';
import { InputsModule, SharedModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ExcelModule } from '@progress/kendo-angular-treelist';
import { PDFModule } from '@progress/kendo-angular-scheduler';


@NgModule({
  declarations: [
    ClienteusuarioListComponent
  ],
  imports: [
    CommonModule,
    ClienteusuarioListRoutingModule,
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
export class ClienteusuarioListModule { }
