import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipopermisoEditRoutingModule } from './tipopermiso-edit-routing.module';
import { TipopermisoEditComponent } from './tipopermiso-edit.component';


@NgModule({
  declarations: [
    TipopermisoEditComponent
  ],
  imports: [
    CommonModule,
    TipopermisoEditRoutingModule
  ]
})
export class TipopermisoEditModule { }
