import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EstadodanioListRoutingModule } from './estadodanio-list-routing.module';
import { EstadodanioListComponent } from './estadodanio-list.component';
import { AlertModule, BadgeModule, ButtonModule, CardModule, CollapseModule, GridModule, SharedModule, SmartTableModule, TableModule, UtilitiesModule, ButtonGroupModule, DropdownModule } from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    EstadodanioListComponent
  ],
  imports: [
    CommonModule,
    EstadodanioListRoutingModule,
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
export class EstadodanioListModule { }
