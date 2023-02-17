import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipoespecieListRoutingModule } from './tipoespecie-list-routing.module';
import { TipoespecieListComponent } from './tipoespecie-list.component';
import { AlertModule, BadgeModule, ButtonModule, CardModule, CollapseModule, GridModule, SharedModule, SmartTableModule, TableModule, UtilitiesModule, ButtonGroupModule, DropdownModule } from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    TipoespecieListComponent
  ],
  imports: [
    CommonModule,
    TipoespecieListRoutingModule,
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
export class TipoespecieListModule { }
