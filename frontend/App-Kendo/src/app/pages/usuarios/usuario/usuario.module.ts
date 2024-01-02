import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuarioRoutingModule } from './usuario-routing.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    UsuarioRoutingModule,
    StoreModule.forFeature('usuarioregistro', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class UsuarioModule { }
