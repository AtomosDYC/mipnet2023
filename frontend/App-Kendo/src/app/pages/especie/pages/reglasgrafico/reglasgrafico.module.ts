import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReglasgraficoComponent } from './reglasgrafico.component';



@NgModule({
  declarations: [
    ReglasgraficoComponent
  ],
  exports:[
    ReglasgraficoComponent
  ],
  imports: [
    CommonModule
  ]
})
export class ReglasgraficoModule { }
