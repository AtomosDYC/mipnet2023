import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PlantillaListRoutingModule } from './plantilla-list-routing.module';
import { PlantillaListComponent } from './plantilla-list.component';
import { AlertModule, BadgeModule, ButtonModule, CardModule, CollapseModule, GridModule, SharedModule, SmartTableModule, TableModule, UtilitiesModule, ButtonGroupModule, DropdownModule } from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    PlantillaListComponent
  ],
  imports: [
    CommonModule,
    PlantillaListRoutingModule,
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
export class PlantillaListModule { }
