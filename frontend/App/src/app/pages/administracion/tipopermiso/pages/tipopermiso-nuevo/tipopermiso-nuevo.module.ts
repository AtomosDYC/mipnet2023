import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipopermisoNuevoRoutingModule } from './tipopermiso-nuevo-routing.module';
import { TipopermisoNuevoComponent } from './tipopermiso-nuevo.component';


@NgModule({
  declarations: [
    TipopermisoNuevoComponent
  ],
  imports: [
    CommonModule,
    TipopermisoNuevoRoutingModule
  ]
})
export class TipopermisoNuevoModule { }
