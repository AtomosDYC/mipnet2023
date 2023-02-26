import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipocompersonaNuevoRoutingModule } from './tipocompersona-nuevo-routing.module';
import { TipocompersonaNuevoComponent } from './tipocompersona-nuevo.component';
import { GridModule, AlertModule, BadgeModule, ButtonModule, CardModule, CollapseModule, SharedModule, UtilitiesModule, DropdownModule, TableModule } from '@coreui/angular-pro';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SpinerModule } from '../../../../../shared/indicators/spiner/spiner.module';


@NgModule({
  declarations: [
    TipocompersonaNuevoComponent
  ],
  imports: [
    CommonModule,
    TipocompersonaNuevoRoutingModule,
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
export class TipocompersonaNuevoModule { }
