import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipoflujoListRoutingModule } from './tipoflujo-list-routing.module';
import { TipoflujoListComponent } from './tipoflujo-list.component';
import { AlertModule, BadgeModule, ButtonModule, CardModule, CollapseModule, GridModule, SharedModule, SmartTableModule, TableModule, UtilitiesModule, ButtonGroupModule, DropdownModule } from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    TipoflujoListComponent
  ],
  imports: [
    CommonModule,
    TipoflujoListRoutingModule,
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
export class TipoflujoListModule { }
