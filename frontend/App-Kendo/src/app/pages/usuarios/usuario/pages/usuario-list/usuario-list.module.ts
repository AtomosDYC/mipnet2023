import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuarioListRoutingModule } from './usuario-list-routing.module';
import { UsuarioListComponent } from './usuario-list.component';
import { ButtonModule, ButtonGroupModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { GridModule, ExcelModule, PDFModule } from '@progress/kendo-angular-grid';
import { SharedModule, InputsModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { IconsModule } from '@progress/kendo-angular-icons';


@NgModule({
  declarations: [
    UsuarioListComponent
  ],
  imports: [
    CommonModule,
    UsuarioListRoutingModule,
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
export class UsuarioListModule { }
