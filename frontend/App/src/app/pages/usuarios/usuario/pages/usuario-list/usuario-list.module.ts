import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuarioListRoutingModule } from './usuario-list-routing.module';
import { UsuarioListComponent } from './usuario-list.component';
import { DropdownModule, ButtonGroupModule, UtilitiesModule, TableModule, SmartTableModule, SharedModule, GridModule, CollapseModule, CardModule, ButtonModule, BadgeModule, AlertModule } from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    UsuarioListComponent
  ],
  imports: [
    CommonModule,
    UsuarioListRoutingModule,
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
export class UsuarioListModule { }
