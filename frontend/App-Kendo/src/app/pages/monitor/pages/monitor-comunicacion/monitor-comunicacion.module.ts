import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MonitorComunicacionComponent } from './monitor-comunicacion.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { ButtonGroupModule, ButtonModule, ButtonsModule } from '@progress/kendo-angular-buttons';
import { ComboBoxModule, DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { CardModule, LayoutModule } from '@progress/kendo-angular-layout';

import { LabelModule } from '@progress/kendo-angular-label';
import { GridModule } from '@progress/kendo-angular-grid';
import { SharedModule } from '@progress/kendo-angular-scheduler';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { effects, reducers } from './store';



@NgModule({
  declarations: [
    MonitorComunicacionComponent
  ],
  exports: [
    MonitorComunicacionComponent
  ],
  imports: [
    CommonModule,
    ButtonModule,
    CardModule,
    GridModule,
    SharedModule,
    InputsModule,
    LabelModule,
    ButtonGroupModule,
    DropDownsModule,
    
    FormsModule,
    ReactiveFormsModule,
    StoreModule.forFeature('monitorcomunicacion', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class MonitorComunicacionModule { }
