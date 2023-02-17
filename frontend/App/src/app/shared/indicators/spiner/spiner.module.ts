import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpinerComponent } from './spiner.component';
import { SpinnerModule } from '@coreui/angular-pro';


@NgModule({
  declarations: [
    SpinerComponent
  ],
  imports: [
    CommonModule,
    SpinnerModule
  ],
  exports: [
    SpinerComponent
  ]
})
export class SpinerModule { }
