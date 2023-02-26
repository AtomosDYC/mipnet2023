import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipoparametroEditRoutingModule } from './tipoparametro-edit-routing.module';
import { TipoparametroEditComponent } from './tipoparametro-edit.component';


@NgModule({
  declarations: [
    TipoparametroEditComponent
  ],
  imports: [
    CommonModule,
    TipoparametroEditRoutingModule
  ]
})
export class TipoparametroEditModule { }
