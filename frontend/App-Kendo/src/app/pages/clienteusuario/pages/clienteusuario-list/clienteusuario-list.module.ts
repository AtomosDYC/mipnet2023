import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClienteusuarioListRoutingModule } from './clienteusuario-list-routing.module';
import { ClienteusuarioListComponent } from './clienteusuario-list.component';


@NgModule({
  declarations: [
    ClienteusuarioListComponent
  ],
  imports: [
    CommonModule,
    ClienteusuarioListRoutingModule
  ]
})
export class ClienteusuarioListModule { }
