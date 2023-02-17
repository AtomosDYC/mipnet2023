import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InmuebleListRoutingModule } from './inmueble-list-routing.module';
import { InmuebleListComponent } from './inmueble-list.component';

import {
  CardModule,
  GridModule,
  TableModule
} from '@coreui/angular-pro';

@NgModule({
  declarations: [
    InmuebleListComponent
  ],
  imports: [
    CommonModule,
    InmuebleListRoutingModule,
    CardModule,
    GridModule,
    TableModule

  ]
})
export class InmuebleListModule { }
