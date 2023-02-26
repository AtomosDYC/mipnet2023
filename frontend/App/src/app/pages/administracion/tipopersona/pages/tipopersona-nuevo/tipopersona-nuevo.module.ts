import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipopersonaNuevoRoutingModule } from './tipopersona-nuevo-routing.module';
import { TipopersonaNuevoComponent } from './tipopersona-nuevo.component';
import { GridModule, AlertModule, BadgeModule, ButtonModule, CardModule, CollapseModule, SharedModule, UtilitiesModule, DropdownModule, TableModule } from '@coreui/angular-pro';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SpinerModule } from '../../../../../shared/indicators/spiner/spiner.module';


@NgModule({
  declarations: [
    TipopersonaNuevoComponent
  ],
  imports: [
    CommonModule,
    TipopersonaNuevoRoutingModule,
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
export class TipopersonaNuevoModule { }
