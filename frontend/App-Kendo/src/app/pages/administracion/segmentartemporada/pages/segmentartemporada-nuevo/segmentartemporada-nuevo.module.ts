import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SegmentartemporadaNuevoRoutingModule } from './segmentartemporada-nuevo-routing.module';
import { SegmentartemporadaNuevoComponent } from './segmentartemporada-nuevo.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';


@NgModule({
  declarations: [
    SegmentartemporadaNuevoComponent
  ],
  imports: [
    CommonModule,
    SegmentartemporadaNuevoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
  ]
})
export class SegmentartemporadaNuevoModule { }
