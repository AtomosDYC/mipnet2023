import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MonitorRoutingModule } from './monitor-routing.module';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { effects, reducers } from './store';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MonitorRoutingModule,
    StoreModule.forFeature('monitor', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class MonitorModule { }
 