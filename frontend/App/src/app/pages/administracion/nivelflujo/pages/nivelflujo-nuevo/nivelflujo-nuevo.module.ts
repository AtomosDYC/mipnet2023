import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NivelflujoNuevoRoutingModule } from './nivelflujo-nuevo-routing.module';
import { NivelflujoNuevoComponent } from './nivelflujo-nuevo.component';


@NgModule({
  declarations: [
    NivelflujoNuevoComponent
  ],
  imports: [
    CommonModule,
    NivelflujoNuevoRoutingModule
  ]
})
export class NivelflujoNuevoModule { }
