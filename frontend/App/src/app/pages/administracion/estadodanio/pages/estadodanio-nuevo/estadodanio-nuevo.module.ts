import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EstadodanioNuevoRoutingModule } from './estadodanio-nuevo-routing.module';
import { EstadodanioNuevoComponent } from './estadodanio-nuevo.component';


@NgModule({
  declarations: [
    EstadodanioNuevoComponent
  ],
  imports: [
    CommonModule,
    EstadodanioNuevoRoutingModule
  ]
})
export class EstadodanioNuevoModule { }
