import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ComunaEditRoutingModule } from './comuna-edit-routing.module';
import { ComunaEditComponent } from './comuna-edit.component';
import { GridModule, ButtonModule, CardModule, CollapseModule, UtilitiesModule, TableModule, FormModule } from '@coreui/angular-pro';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SpinerModule } from '../../../../../shared/indicators/spiner/spiner.module';


@NgModule({
  declarations: [
    ComunaEditComponent
  ],
  imports: [
    CommonModule,
    ComunaEditRoutingModule,
    GridModule,
    ButtonModule,
    CardModule,
    CollapseModule,
    UtilitiesModule,
    FormsModule,
    ReactiveFormsModule,
    TableModule,
    SpinerModule,
    FormModule
  ]
})
export class ComunaEditModule { }
