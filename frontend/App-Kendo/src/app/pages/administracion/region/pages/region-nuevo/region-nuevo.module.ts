import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegionNuevoRoutingModule } from './region-nuevo-routing.module';
import { RegionNuevoComponent } from './region-nuevo.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule, ButtonsModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { InputsModule, SharedModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';


@NgModule({
  declarations: [
    RegionNuevoComponent
  ],
  imports: [
    CommonModule,
    RegionNuevoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
    
  ]
})
export class RegionNuevoModule { }
