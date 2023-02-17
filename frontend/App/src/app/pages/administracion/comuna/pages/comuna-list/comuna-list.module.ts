import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ComunaListRoutingModule } from './comuna-list-routing.module';
import { ComunaListComponent } from './comuna-list.component';

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
    ComunaListComponent
  ],
  imports: [
    CommonModule,
    ComunaListRoutingModule,
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
export class ComunaListModule { }
