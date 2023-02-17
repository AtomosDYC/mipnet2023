import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PlantillaListComponent } from './plantilla-list.component';

const routes: Routes = [
  {
    path:'',
    component:PlantillaListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PlantillaListRoutingModule { }
