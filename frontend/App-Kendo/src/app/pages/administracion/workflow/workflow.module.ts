import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WorkflowRoutingModule } from './workflow-routing.module';
import { WorkflowContenedorModule } from './pages/workflow-contenedor/workflow-contenedor.module';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    WorkflowRoutingModule,
    WorkflowContenedorModule,
    StoreModule.forFeature('workflow', reducers),
    EffectsModule.forFeature(effects),

  ]
})
export class WorkflowModule { }
