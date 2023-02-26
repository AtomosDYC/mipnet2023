import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NivelflujoEditRoutingModule } from './nivelflujo-edit-routing.module';
import { NivelflujoEditComponent } from './nivelflujo-edit.component';


@NgModule({
  declarations: [
    NivelflujoEditComponent
  ],
  imports: [
    CommonModule,
    NivelflujoEditRoutingModule
  ]
})
export class NivelflujoEditModule { }
