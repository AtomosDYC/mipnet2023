import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RolesListRoutingModule } from './roles-list-routing.module';
import { RolesListComponent } from './roles-list.component';
import { DropdownModule, ButtonGroupModule, UtilitiesModule, TableModule, SmartTableModule, SharedModule, GridModule, CollapseModule, CardModule, ButtonModule, BadgeModule, AlertModule } from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    RolesListComponent
  ],
  imports: [
    CommonModule,
    RolesListRoutingModule,
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
export class RolesListModule { }
