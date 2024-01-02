import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonasNuevoRoutingModule } from './personas-nuevo-routing.module';
import { PersonasNuevoComponent } from './personas-nuevo.component';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { PersonasContenedorModule } from '../personas-contenedor/personas-contenedor.module';


@NgModule({
  declarations: [
    PersonasNuevoComponent
  ],
  imports: [
    CommonModule,
    PersonasNuevoRoutingModule,
    PersonasContenedorModule,
    LayoutModule
  ]
})
export class PersonasNuevoModule { }
