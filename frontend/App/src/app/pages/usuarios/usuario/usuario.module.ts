import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuarioRoutingModule } from './usuario-routing.module';
import { effects, reducers } from './store/index';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    UsuarioRoutingModule,
    StoreModule.forFeature('usuario', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class UsuarioModule { }
