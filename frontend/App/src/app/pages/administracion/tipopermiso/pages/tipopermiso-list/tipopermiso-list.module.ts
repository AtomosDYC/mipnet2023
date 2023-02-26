import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipopermisoListRoutingModule } from './tipopermiso-list-routing.module';
import { TipopermisoListComponent } from './tipopermiso-list.component';
import { AlertModule, BadgeModule, ButtonModule, CardModule, CollapseModule, GridModule, SharedModule, SmartTableModule, TableModule, UtilitiesModule, ButtonGroupModule, DropdownModule } from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    TipopermisoListComponent
  ],
  imports: [
    CommonModule,
    TipopermisoListRoutingModule,
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
export class TipopermisoListModule { }
