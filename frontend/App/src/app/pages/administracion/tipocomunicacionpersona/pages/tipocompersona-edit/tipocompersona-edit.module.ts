import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipocompersonaEditRoutingModule } from './tipocompersona-edit-routing.module';
import { TipocompersonaEditComponent } from './tipocompersona-edit.component';
import { GridModule, ButtonModule, CardModule, CollapseModule, UtilitiesModule, TableModule } from '@coreui/angular-pro';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SpinerModule } from '../../../../../shared/indicators/spiner/spiner.module';
import { TipopercomunicacionListModule } from '../../../tipopercomunicacion/pages/tipopercomunicacion-list/tipopercomunicacion-list.module';
import { TipopercomunicacionModule } from '../../../tipopercomunicacion/tipopercomunicacion.module';


@NgModule({
  declarations: [
    TipocompersonaEditComponent
  ],
  imports: [
    CommonModule,

    TipocompersonaEditRoutingModule,

    TipopercomunicacionModule,

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
export class TipocompersonaEditModule { }
