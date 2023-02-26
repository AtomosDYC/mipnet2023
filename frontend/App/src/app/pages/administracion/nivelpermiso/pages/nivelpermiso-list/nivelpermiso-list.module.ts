import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NivelpermisoListRoutingModule } from './nivelpermiso-list-routing.module';
import { NivelpermisoListComponent } from './nivelpermiso-list.component';
import { AlertModule, BadgeModule, ButtonModule, CardModule, CollapseModule, GridModule, SharedModule, SmartTableModule, TableModule, UtilitiesModule, ButtonGroupModule, DropdownModule } from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    NivelpermisoListComponent
  ],
  imports: [
    CommonModule,
    NivelpermisoListRoutingModule,
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
export class NivelpermisoListModule { }
