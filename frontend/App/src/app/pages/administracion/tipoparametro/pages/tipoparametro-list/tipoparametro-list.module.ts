import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TipoparametroListRoutingModule } from './tipoparametro-list-routing.module';
import { TipoparametroListComponent } from './tipoparametro-list.component';
import { AlertModule, BadgeModule, ButtonModule, CardModule, CollapseModule, GridModule, SharedModule, SmartTableModule, TableModule, UtilitiesModule, ButtonGroupModule, DropdownModule } from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    TipoparametroListComponent
  ],
  imports: [
    CommonModule,
    TipoparametroListRoutingModule,
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
export class TipoparametroListModule { }
