import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BadgeModule, CardModule, GridModule } from '@coreui/angular-pro';
import { ChartjsModule } from '@coreui/angular-pro-chartjs';

import { ChartsComponent } from './charts.component';
import { ChartsRoutingModule } from './charts-routing.module';
import { DocsComponentsModule } from '@docs-components/docs-components.module';

@NgModule({
  declarations: [ChartsComponent],
  imports: [
    CommonModule,
    ChartsRoutingModule,
    ChartjsModule,
    CardModule,
    GridModule,
    BadgeModule,
    DocsComponentsModule
  ]
})
export class ChartsModule {
}
