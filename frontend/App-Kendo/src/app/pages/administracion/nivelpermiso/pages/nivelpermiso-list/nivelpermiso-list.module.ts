import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NivelpermisoListRoutingModule } from './nivelpermiso-list-routing.module';
import { NivelpermisoListComponent } from './nivelpermiso-list.component';
import { ButtonModule, ButtonGroupModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { GridModule, ExcelModule, PDFModule } from '@progress/kendo-angular-grid';
import { SharedModule, InputsModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';



@NgModule({
  declarations: [
    NivelpermisoListComponent
  ],
  imports: [
    CommonModule,
    NivelpermisoListRoutingModule,
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
export class NivelpermisoListModule { }
