import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RolesRoutingModule } from './roles-routing.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RolesRoutingModule,
    StoreModule.forFeature('roles', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class RolesModule { }
