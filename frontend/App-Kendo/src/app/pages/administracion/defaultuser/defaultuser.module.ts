import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DefaultuserRoutingModule } from './defaultuser-routing.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    DefaultuserRoutingModule,
    StoreModule.forFeature('defaultuser', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class DefaultuserModule { }
