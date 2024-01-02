import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MonitorAccesoComponent } from './monitor-acceso.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { effects, reducers } from './store';




@NgModule({
  declarations: [
    MonitorAccesoComponent
  ],
  exports : [
    MonitorAccesoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
    StoreModule.forFeature('monitoracceso', reducers),
    EffectsModule.forFeature(effects),
    
  ]
})
export class MonitorAccesoModule { }
