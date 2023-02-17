import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StaticRoutingModule } from './static-routing.module';
import { WelcomeModule } from './pages/welcome/welcome.module';
import { NotFoundModule } from './pages/not-found/not-found.module';
import { Error500Module } from './pages/error500/error500.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    StaticRoutingModule,
    WelcomeModule,
    NotFoundModule,
    Error500Module
  ],
  exports: [

  ]
})
export class StaticModule { }
