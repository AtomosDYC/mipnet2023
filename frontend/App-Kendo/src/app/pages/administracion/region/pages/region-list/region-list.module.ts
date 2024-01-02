import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegionListRoutingModule } from './region-list-routing.module';
import { RegionListComponent } from './region-list.component';
import { ButtonGroupModule, ButtonModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { GridModule, ExcelModule, PDFModule } from '@progress/kendo-angular-grid';
import { SharedModule, InputsModule } from '@progress/kendo-angular-inputs';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { LabelModule } from '@progress/kendo-angular-label';




@NgModule({
  declarations: [
    RegionListComponent
  ],
    imports: [
    CommonModule,
    RegionListRoutingModule,
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
export class RegionListModule { }
