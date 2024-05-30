import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClienteestacionRoutingModule } from './clienteestacion-routing.module';
import { effects, reducers } from './store';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';


@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    ClienteestacionRoutingModule,
    StoreModule.forFeature('clienteestacion', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class ClienteestacionModule { }
