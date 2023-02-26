import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipopersonaListRoutingModule } from './tipopersona-list-routing.module';
import { TipopersonaListComponent } from './tipopersona-list.component';
import { AlertModule, BadgeModule, ButtonModule, CardModule, CollapseModule, GridModule, SharedModule, SmartTableModule, TableModule, UtilitiesModule, ButtonGroupModule, DropdownModule } from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    TipopersonaListComponent
  ],
  imports: [
    CommonModule,
    TipopersonaListRoutingModule,
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
export class TipopersonaListModule { }
