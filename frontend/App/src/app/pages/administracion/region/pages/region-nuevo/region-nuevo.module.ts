import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegionNuevoRoutingModule } from './region-nuevo-routing.module';
import { RegionNuevoComponent } from './region-nuevo.component';
import { GridModule, AlertModule, BadgeModule, ButtonModule, CardModule, CollapseModule, SharedModule, SmartTableModule, TableModule, UtilitiesModule, ButtonGroupModule, DropdownModule } from '@coreui/angular-pro';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SpinerModule } from '../../../../../shared/indicators/spiner/spiner.module';


@NgModule({
  declarations: [
    RegionNuevoComponent
  ],
  imports: [
    CommonModule,
    RegionNuevoRoutingModule,
    GridModule,
    AlertModule,
    BadgeModule,
    ButtonModule,
    CardModule,
    CollapseModule,
    GridModule,
    SharedModule,
    UtilitiesModule,
    DropdownModule,
    FormsModule,
    ReactiveFormsModule,
    TableModule,
    SpinerModule,
  ]
})
export class RegionNuevoModule { }
