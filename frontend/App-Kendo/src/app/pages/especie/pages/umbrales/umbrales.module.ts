import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UmbralesComponent } from './umbrales.component';
import { ButtonGroupModule, ButtonModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { GridModule } from '@progress/kendo-angular-grid';
import { InputsModule, SharedModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { effects, reducers } from './store';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';



@NgModule({
  declarations: [
    UmbralesComponent
  ],
  exports:[
    UmbralesComponent
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
    StoreModule.forFeature('especieumbral', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class UmbralesModule { }
