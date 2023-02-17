import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MedidaumbralEditRoutingModule } from './medidaumbral-edit-routing.module';
import { MedidaumbralEditComponent } from './medidaumbral-edit.component';


@NgModule({
  declarations: [
    MedidaumbralEditComponent
  ],
  imports: [
    CommonModule,
    MedidaumbralEditRoutingModule
  ]
})
export class MedidaumbralEditModule { }
