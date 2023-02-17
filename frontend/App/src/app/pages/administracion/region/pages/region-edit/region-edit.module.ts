import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegionEditRoutingModule } from './region-edit-routing.module';
import { RegionEditComponent } from './region-edit.component';
import { GridModule, ButtonModule, CardModule, CollapseModule, UtilitiesModule, TableModule } from '@coreui/angular-pro';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SpinerModule } from '../../../../../shared/indicators/spiner/spiner.module';


@NgModule({
  declarations: [
    RegionEditComponent
  ],
  imports: [
    CommonModule,
    RegionEditRoutingModule,
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
export class RegionEditModule { }
