import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegionListRoutingModule } from './region-list-routing.module';
import { RegionListComponent } from './region-list.component';

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
    RegionListComponent
  ],
    imports: [
    CommonModule,
    RegionListRoutingModule,
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
export class RegionListModule { }
