import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PlantillaNuevoRoutingModule } from './plantilla-nuevo-routing.module';
import { PlantillaNuevoComponent } from './plantilla-nuevo.component';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { PlantillaDatosgeneralesModule } from '../plantilla-datosgenerales/plantilla-datosgenerales.module';
import { PlantillaPermisosModule } from '../plantilla-permisos/plantilla-permisos.module';

@NgModule({
  declarations: [
    PlantillaNuevoComponent
  ],
  imports: [
    CommonModule,
    PlantillaNuevoRoutingModule,
    PlantillaDatosgeneralesModule,
    PlantillaPermisosModule,
    LayoutModule,
    
  ]
})
export class PlantillaNuevoModule { }
