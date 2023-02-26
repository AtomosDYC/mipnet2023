import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipocompersonaListRoutingModule } from './tipocompersona-list-routing.module';
import { TipocompersonaListComponent } from './tipocompersona-list.component';
import { AlertModule, BadgeModule, ButtonModule, CardModule, CollapseModule, GridModule, SharedModule, SmartTableModule, TableModule, UtilitiesModule, ButtonGroupModule, DropdownModule } from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    TipocompersonaListComponent

  ],
  imports: [
    CommonModule,
    TipocompersonaListRoutingModule,
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
export class TipocompersonaListModule { }
