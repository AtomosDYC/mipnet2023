import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegionEditRoutingModule } from './region-edit-routing.module';
import { RegionEditComponent } from './region-edit.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GridModule } from '@progress/kendo-angular-grid';
import { ButtonModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';



@NgModule({
  declarations: [
    RegionEditComponent
  ],
  imports: [
    CommonModule,
    RegionEditRoutingModule,
    GridModule,
    ButtonModule,
    CardModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class RegionEditModule { }
