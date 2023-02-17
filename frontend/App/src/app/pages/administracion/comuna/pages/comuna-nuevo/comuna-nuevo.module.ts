import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ComunaNuevoRoutingModule } from './comuna-nuevo-routing.module';
import { ComunaNuevoComponent } from './comuna-nuevo.component';
import { GridModule, AlertModule, BadgeModule, ButtonModule, CardModule, CollapseModule, SharedModule, UtilitiesModule, DropdownModule, TableModule, FormModule } from '@coreui/angular-pro';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SpinerModule } from '../../../../../shared/indicators/spiner/spiner.module';


@NgModule({
  declarations: [
    ComunaNuevoComponent
  ],
  imports: [
    CommonModule,
    ComunaNuevoRoutingModule,
    GridModule,
    AlertModule,
    BadgeModule,
    ButtonModule,
    CardModule,
    CollapseModule,
    GridModule,
    SharedModule,
    UtilitiesModule,
    DropdownModule,
    FormsModule,
    FormModule,
    ReactiveFormsModule,
    TableModule,
    SpinerModule,

  ]
})
export class ComunaNuevoModule { }
