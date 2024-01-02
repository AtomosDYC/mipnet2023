import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MonitorTrampasComponent } from './monitor-trampas.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonGroupModule, ButtonModule, ButtonsModule } from '@progress/kendo-angular-buttons';
import { ComboBoxModule, DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { CardModule, LayoutModule } from '@progress/kendo-angular-layout';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { effects, reducers } from './store';
import { GridModule } from '@progress/kendo-angular-grid';
import { SharedModule } from '@progress/kendo-angular-scheduler';



@NgModule({
  declarations: [
    MonitorTrampasComponent
  ],
  exports : [
    MonitorTrampasComponent
  ],
  imports: [
    CommonModule,
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
    StoreModule.forFeature('monitortrampa', reducers),
    EffectsModule.forFeature(effects),
    
  ]
})
export class MonitorTrampasModule { }
