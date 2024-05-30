import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MonitoreoListRoutingModule } from './monitoreo-list-routing.module';
import { MonitoreoListComponent } from './monitoreo-list.component';


@NgModule({
  declarations: [
    MonitoreoListComponent
  ],
  imports: [
    CommonModule,
    MonitoreoListRoutingModule
  ]
})
export class MonitoreoListModule { }
