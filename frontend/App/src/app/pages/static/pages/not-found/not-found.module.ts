import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NotFoundRoutingModule } from './not-found-routing.module';
import { NotFoundComponent } from './not-found.component';

import {
  FormModule,
  GridModule,
} from '@coreui/angular-pro';

@NgModule({
  declarations: [
    NotFoundComponent,
  ],
  imports: [
    CommonModule,
    NotFoundRoutingModule,
    FormModule,
    GridModule,
  ],
  exports:[
    NotFoundComponent,
  ]
})
export class NotFoundModule { }
