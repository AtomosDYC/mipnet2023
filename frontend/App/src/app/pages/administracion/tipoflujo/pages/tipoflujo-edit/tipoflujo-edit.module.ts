import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipoflujoEditRoutingModule } from './tipoflujo-edit-routing.module';
import { TipoflujoEditComponent } from './tipoflujo-edit.component';


@NgModule({
  declarations: [
    TipoflujoEditComponent
  ],
  imports: [
    CommonModule,
    TipoflujoEditRoutingModule
  ]
})
export class TipoflujoEditModule { }
