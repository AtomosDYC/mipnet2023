import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TipopersonaNuevoComponent } from './tipopersona-nuevo.component';

const routes: Routes = [
  {
    path:'',
    component:TipopersonaNuevoComponent,
    data: { titulo: 'Matenimiento de tipo de persona' }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TipopersonaNuevoRoutingModule { }
