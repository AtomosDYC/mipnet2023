import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipoflujoNuevoRoutingModule } from './tipoflujo-nuevo-routing.module';
import { TipoflujoNuevoComponent } from './tipoflujo-nuevo.component';


@NgModule({
  declarations: [
    TipoflujoNuevoComponent
  ],
  imports: [
    CommonModule,
    TipoflujoNuevoRoutingModule
  ]
})
export class TipoflujoNuevoModule { }
