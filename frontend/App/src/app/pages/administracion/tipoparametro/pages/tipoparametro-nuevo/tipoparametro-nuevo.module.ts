import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipoparametroNuevoRoutingModule } from './tipoparametro-nuevo-routing.module';
import { TipoparametroNuevoComponent } from './tipoparametro-nuevo.component';


@NgModule({
  declarations: [
    TipoparametroNuevoComponent
  ],
  imports: [
    CommonModule,
    TipoparametroNuevoRoutingModule
  ]
})
export class TipoparametroNuevoModule { }
