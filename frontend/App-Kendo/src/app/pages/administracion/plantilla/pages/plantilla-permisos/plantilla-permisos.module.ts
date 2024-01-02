import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlantillaPermisosComponent } from './plantilla-permisos.component';
import { TreeListModule } from '@progress/kendo-angular-treelist';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { ComboBoxModule, DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { LayoutModule } from '@progress/kendo-angular-layout';


import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducers, effects } from './store';


@NgModule({
  declarations: [
    PlantillaPermisosComponent
  ],
  exports: [
    PlantillaPermisosComponent
  ],
  imports: [
    CommonModule,
    TreeListModule,
    FormsModule,
    ReactiveFormsModule,
    InputsModule,
    DateInputsModule,
    LabelModule,
    ButtonsModule,
    
    DropDownsModule,
    ComboBoxModule,
    LayoutModule,
    

    StoreModule.forFeature('plantillaflujo', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class PlantillaPermisosModule { }
