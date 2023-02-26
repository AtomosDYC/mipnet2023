import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SaludoListRoutingModule } from './saludo-list-routing.module';
import { SaludoListComponent } from './saludo-list.component';
import { AlertModule, BadgeModule, ButtonModule, CardModule, CollapseModule, GridModule, SharedModule, SmartTableModule, TableModule, UtilitiesModule, ButtonGroupModule, DropdownModule } from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    SaludoListComponent
  ],
  imports: [
    CommonModule,
    SaludoListRoutingModule,
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
export class SaludoListModule { }
