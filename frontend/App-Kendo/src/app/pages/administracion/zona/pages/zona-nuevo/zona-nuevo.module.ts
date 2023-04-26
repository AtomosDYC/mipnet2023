import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ZonaNuevoRoutingModule } from './zona-nuevo-routing.module';
import { ZonaNuevoComponent } from './zona-nuevo.component';


@NgModule({
  declarations: [
    ZonaNuevoComponent
  ],
  imports: [
    CommonModule,
    ZonaNuevoRoutingModule
  ]
})
export class ZonaNuevoModule { }
