import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClienteestacionListRoutingModule } from './clienteestacion-list-routing.module';
import { ButtonGroupModule, ButtonModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { GridModule } from '@progress/kendo-angular-grid';
import { InputsModule, SharedModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ExcelModule } from '@progress/kendo-angular-treelist';
import { PDFModule } from '@progress/kendo-angular-scheduler';
import { ClienteestacionListComponent } from './clienteestacion-list.component';


@NgModule({
  declarations: [ClienteestacionListComponent],
  imports: [
    CommonModule,
    ClienteestacionListRoutingModule,
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
export class ClienteestacionListModule { }
