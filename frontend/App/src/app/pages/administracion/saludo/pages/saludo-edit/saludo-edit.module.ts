import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SaludoEditRoutingModule } from './saludo-edit-routing.module';
import { SaludoEditComponent } from './saludo-edit.component';
import { GridModule, ButtonModule, CardModule, CollapseModule, UtilitiesModule, TableModule } from '@coreui/angular-pro';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SpinerModule } from '../../../../../shared/indicators/spiner/spiner.module';


@NgModule({
  declarations: [
    SaludoEditComponent
  ],
  imports: [
    CommonModule,
    SaludoEditRoutingModule,
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
export class SaludoEditModule { }
