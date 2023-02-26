import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NivelflujoListRoutingModule } from './nivelflujo-list-routing.module';
import { NivelflujoListComponent } from './nivelflujo-list.component';
import { AlertModule, BadgeModule, ButtonModule, CardModule, CollapseModule, GridModule, SharedModule, SmartTableModule, TableModule, UtilitiesModule, ButtonGroupModule, DropdownModule } from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    NivelflujoListComponent
  ],
  imports: [
    CommonModule,
    NivelflujoListRoutingModule,
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
export class NivelflujoListModule { }
