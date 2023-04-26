import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NotFoundRoutingModule } from './not-found-routing.module';
import { NotFoundComponent } from './not-found.component';
import { FormsModule } from '@angular/forms';
import { GridModule } from '@progress/kendo-angular-grid';


@NgModule({
  declarations: [
    NotFoundComponent,
  ],
  imports: [
    CommonModule,
    NotFoundRoutingModule,
    FormsModule ,
    GridModule,
  ],
  exports:[
    NotFoundComponent,
  ]
})
export class NotFoundModule { }
