import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EspecieUnirespecieComponent } from './especie-unirespecie.component';
import { ButtonGroupModule, ButtonModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { GridModule } from '@progress/kendo-angular-grid';
import { InputsModule, SharedModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { effects, reducers } from './store';



@NgModule({
  declarations: [
    EspecieUnirespecieComponent
  ],
  exports:[
    EspecieUnirespecieComponent
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
    InputsModule,
    StoreModule.forFeature('unirespecie', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class EspecieUnirespecieModule { }
