import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SaludoNuevoRoutingModule } from './saludo-nuevo-routing.module';
import { SaludoNuevoComponent } from './saludo-nuevo.component';
import { SpinerModule } from '../../../../../shared/indicators/spiner/spiner.module';
import { TableModule, DropdownModule, UtilitiesModule, SharedModule, GridModule, CollapseModule, CardModule, ButtonModule, BadgeModule, AlertModule } from '@coreui/angular-pro';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    SaludoNuevoComponent
  ],
  imports: [
    CommonModule,
    SaludoNuevoRoutingModule,
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
    ReactiveFormsModule,
    TableModule,
    SpinerModule,
  ]
})
export class SaludoNuevoModule { }
