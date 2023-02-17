import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MedidaumbralNuevoRoutingModule } from './medidaumbral-nuevo-routing.module';
import { MedidaumbralNuevoComponent } from './medidaumbral-nuevo.component';


@NgModule({
  declarations: [
    MedidaumbralNuevoComponent
  ],
  imports: [
    CommonModule,
    MedidaumbralNuevoRoutingModule
  ]
})
export class MedidaumbralNuevoModule { }
