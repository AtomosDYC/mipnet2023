import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TipopercomunicacionListComponent } from './tipopercomunicacion-list.component';
import { AlertModule, BadgeModule, ButtonModule, CardModule, CollapseModule, GridModule, SharedModule, SmartTableModule, TableModule, UtilitiesModule, ButtonGroupModule, DropdownModule, FormModule } from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SpinerModule } from '../../../../../shared/indicators/spiner/spiner.module';



@NgModule({
  declarations: [
    TipopercomunicacionListComponent
  ],
  exports: [
    TipopercomunicacionListComponent
  ],
  imports: [
    CommonModule,
    AlertModule,
    BadgeModule,
    ButtonModule,
    CardModule,
    CollapseModule,
    GridModule,
    SharedModule,
    SmartTableModule,
    TableModule,
    UtilitiesModule,
    IconModule,
    ButtonGroupModule,
    DropdownModule,
    FormsModule,
    FormModule,
    ReactiveFormsModule,
    TableModule,
    SpinerModule,
  ]
})
export class TipopercomunicacionListModule { }
