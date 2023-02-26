import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipopersonaEditRoutingModule } from './tipopersona-edit-routing.module';
import { TipopersonaEditComponent } from './tipopersona-edit.component';
import { GridModule, ButtonModule, CardModule, CollapseModule, UtilitiesModule, TableModule } from '@coreui/angular-pro';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SpinerModule } from '../../../../../shared/indicators/spiner/spiner.module';


@NgModule({
  declarations: [
    TipopersonaEditComponent
  ],
  imports: [
    CommonModule,
    TipopersonaEditRoutingModule,
    GridModule,
    ButtonModule,
    CardModule,
    CollapseModule,
    UtilitiesModule,
    FormsModule,
    ReactiveFormsModule,
    TableModule,
    SpinerModule,
  ]
})
export class TipopersonaEditModule { }
