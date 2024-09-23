import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClienteestacionEstacionesComponent } from './clienteestacion-estaciones.component';
import { ButtonGroupModule, ButtonModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { GridModule } from '@progress/kendo-angular-grid';
import { InputsModule, SharedModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { effects, reducers } from './store';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';



@NgModule({
  declarations: [
    ClienteestacionEstacionesComponent
  ],
  exports: [
    ClienteestacionEstacionesComponent
  ],
  imports: [
    CommonModule,
    ButtonModule,
    CardModule,
    GridModule,
    SharedModule,
    InputsModule,
    LabelModule,
    ButtonGroupModule,
    DropDownsModule,
    
    FormsModule,
    ReactiveFormsModule,
    StoreModule.forFeature('estacion', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class ClienteestacionEstacionesModule { }
