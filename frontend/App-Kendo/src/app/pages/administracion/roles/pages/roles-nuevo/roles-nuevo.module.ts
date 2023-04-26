import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RolesNuevoRoutingModule } from './roles-nuevo-routing.module';
import { RolesNuevoComponent } from './roles-nuevo.component';


@NgModule({
  declarations: [
    RolesNuevoComponent
  ],
  imports: [
    CommonModule,
    RolesNuevoRoutingModule
  ]
})
export class RolesNuevoModule { }
