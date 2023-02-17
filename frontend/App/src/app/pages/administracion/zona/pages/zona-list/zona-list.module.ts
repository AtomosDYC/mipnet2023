import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ZonaListRoutingModule } from './zona-list-routing.module';
import { ZonaListComponent } from './zona-list.component';

import { IconModule } from '@coreui/icons-angular';
import { ButtonGroupModule, DropdownModule } from '@coreui/angular-pro';

import {
  AlertModule,
  BadgeModule,
  ButtonModule,
  CardModule,
  CollapseModule,
  GridModule,
  SharedModule,
  SmartTableModule,
  TableModule,
  UtilitiesModule

} from '@coreui/angular-pro';

@NgModule({
  declarations: [
    ZonaListComponent
  ],
  imports: [
    CommonModule,
    ZonaListRoutingModule,
    AlertModule,
    BadgeModule,
    ButtonModule,
    CardModule,
    CollapseModule,
    GridModule,
    SharedModule,
    SmartTableModule,
    TableModule,
    UtilitiesModule,
    IconModule,
    ButtonGroupModule,
    DropdownModule
  ]
})
export class ZonaListModule { }
