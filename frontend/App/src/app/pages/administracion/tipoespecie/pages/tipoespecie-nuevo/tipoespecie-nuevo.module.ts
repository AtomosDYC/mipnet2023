import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipoespecieNuevoRoutingModule } from './tipoespecie-nuevo-routing.module';
import { TipoespecieNuevoComponent } from './tipoespecie-nuevo.component';


@NgModule({
  declarations: [
    TipoespecieNuevoComponent
  ],
  imports: [
    CommonModule,
    TipoespecieNuevoRoutingModule
  ]
})
export class TipoespecieNuevoModule { }
