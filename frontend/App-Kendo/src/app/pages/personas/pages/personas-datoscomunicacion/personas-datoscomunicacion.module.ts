import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonasDatoscomunicacionComponent } from './personas-datoscomunicacion.component';
import { ButtonGroupModule, ButtonModule } from '@progress/kendo-angular-buttons';
import { CardModule } from '@progress/kendo-angular-layout';
import { GridModule } from '@progress/kendo-angular-grid';
import { InputsModule, SharedModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { effects, reducers } from './store';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';



@NgModule({
  declarations: [
    PersonasDatoscomunicacionComponent
  ],
  exports: [
    PersonasDatoscomunicacionComponent,
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
    StoreModule.forFeature('personacomunicacion', reducers),
    EffectsModule.forFeature(effects),
  ]
})
export class PersonasDatoscomunicacionModule { }
