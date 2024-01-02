import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EspecieContenedorComponent } from './especie-contenedor.component';
import { EspecieDatosgeneralesModule } from '../especie-datosgenerales/especie-datosgenerales.module';
import { EspecieUnirespecieModule } from '../especie-unirespecie/especie-unirespecie.module';
import { ReglasgraficoModule } from '../reglasgrafico/reglasgrafico.module';
import { TipodatosModule } from '../tipodatos/tipodatos.module';
import { UmbralesModule } from '../umbrales/umbrales.module';



@NgModule({
  declarations: [
    EspecieContenedorComponent,

  ],
  exports: [
    EspecieContenedorComponent
  ],
  imports: [
    CommonModule,
    EspecieDatosgeneralesModule,
    EspecieUnirespecieModule,
    ReglasgraficoModule,
    TipodatosModule,
    UmbralesModule
  ]
})
export class EspecieContenedorModule { }
