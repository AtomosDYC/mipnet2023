import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SegmentartemporadaRoutingModule } from './segmentartemporada-routing.module';
import { effects, reducers } from './store';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';


@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule,
    SegmentartemporadaRoutingModule,
    StoreModule.forFeature('segmentartemporada', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class SegmentartemporadaModule { }
