import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipoespecieEditRoutingModule } from './tipoespecie-edit-routing.module';
import { TipoespecieEditComponent } from './tipoespecie-edit.component';


@NgModule({
  declarations: [
    TipoespecieEditComponent
  ],
  imports: [
    CommonModule,
    TipoespecieEditRoutingModule
  ]
})
export class TipoespecieEditModule { }
