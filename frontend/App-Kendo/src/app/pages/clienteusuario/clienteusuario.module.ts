import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClienteusuarioRoutingModule } from './clienteusuario-routing.module';
import { effects, reducers } from './store';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ClienteusuarioRoutingModule,
    StoreModule.forFeature('clienteusuario', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class ClienteusuarioModule { }
