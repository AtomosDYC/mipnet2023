import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VisarListRoutingModule } from './visar-list-routing.module';
import { VisarListComponent } from './visar-list.component';


@NgModule({
  declarations: [
    VisarListComponent
  ],
  imports: [
    CommonModule,
    VisarListRoutingModule
  ]
})
export class VisarListModule { }
