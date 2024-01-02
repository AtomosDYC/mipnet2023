import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClienteestacionRoutingModule } from './clienteestacion-routing.module';
import { ClienteestacionListComponent } from './pages/clienteestacion-list/clienteestacion-list.component';


@NgModule({
  declarations: [
    ClienteestacionListComponent
  ],
  imports: [
    CommonModule,
    ClienteestacionRoutingModule
  ]
})
export class ClienteestacionModule { }
