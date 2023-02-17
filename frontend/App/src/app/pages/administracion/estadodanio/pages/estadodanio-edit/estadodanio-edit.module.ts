import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EstadodanioEditRoutingModule } from './estadodanio-edit-routing.module';
import { EstadodanioEditComponent } from './estadodanio-edit.component';


@NgModule({
  declarations: [
    EstadodanioEditComponent
  ],
  imports: [
    CommonModule,
    EstadodanioEditRoutingModule
  ]
})
export class EstadodanioEditModule { }
