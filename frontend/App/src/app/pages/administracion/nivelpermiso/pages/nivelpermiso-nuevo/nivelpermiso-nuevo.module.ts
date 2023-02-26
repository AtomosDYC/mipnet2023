import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NivelpermisoNuevoRoutingModule } from './nivelpermiso-nuevo-routing.module';
import { NivelpermisoNuevoComponent } from './nivelpermiso-nuevo.component';


@NgModule({
  declarations: [
    NivelpermisoNuevoComponent
  ],
  imports: [
    CommonModule,
    NivelpermisoNuevoRoutingModule
  ]
})
export class NivelpermisoNuevoModule { }
