import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ZonaListRoutingModule } from './zona-list-routing.module';
import { ZonaListComponent } from './zona-list.component';


@NgModule({
  declarations: [
    ZonaListComponent
  ],
  imports: [
    CommonModule,
    ZonaListRoutingModule
  ]
})
export class ZonaListModule { }
