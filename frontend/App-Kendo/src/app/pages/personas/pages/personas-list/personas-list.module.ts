import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonasListRoutingModule } from './personas-list-routing.module';
import { PersonasListComponent } from './personas-list.component';
import { ButtonGroupModule, ButtonModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { FilterMenuModule, GridModule } from '@progress/kendo-angular-grid';
import { InputsModule, SharedModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

import { ExcelModule } from '@progress/kendo-angular-treelist';
import { PDFModule } from '@progress/kendo-angular-scheduler';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { FilterModule } from "@progress/kendo-angular-filter";
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  declarations: [
    PersonasListComponent
  ],
  imports: [
    CommonModule,
    PersonasListRoutingModule,
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
export class PersonasListModule { }
