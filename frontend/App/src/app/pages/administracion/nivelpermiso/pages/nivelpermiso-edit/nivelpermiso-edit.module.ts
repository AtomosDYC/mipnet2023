import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NivelpermisoEditRoutingModule } from './nivelpermiso-edit-routing.module';
import { NivelpermisoEditComponent } from './nivelpermiso-edit.component';


@NgModule({
  declarations: [
    NivelpermisoEditComponent
  ],
  imports: [
    CommonModule,
    NivelpermisoEditRoutingModule
  ]
})
export class NivelpermisoEditModule { }
