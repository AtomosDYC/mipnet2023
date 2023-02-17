import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpinnerModule } from '@coreui/angular-pro';
import { SpinerModule } from './spiner/spiner.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SpinnerModule,
    SpinerModule,
  ],
  exports:[
    SpinerModule
  ]
})
export class IndicatorsModule { }
