import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MedidaumbralListRoutingModule } from './medidaumbral-list-routing.module';
import { MedidaumbralListComponent } from './medidaumbral-list.component';
import { AlertModule, BadgeModule, ButtonModule, CardModule, CollapseModule, GridModule, SharedModule, SmartTableModule, TableModule, UtilitiesModule, ButtonGroupModule, DropdownModule } from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    MedidaumbralListComponent
  ],
  imports: [
    CommonModule,
    MedidaumbralListRoutingModule,
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
export class MedidaumbralListModule { }
