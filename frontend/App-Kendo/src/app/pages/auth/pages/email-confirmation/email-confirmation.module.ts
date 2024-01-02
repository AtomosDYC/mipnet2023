import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmailConfirmationRoutingModule } from './email-confirmation-routing.module';
import { EmailConfirmationComponent } from './email-confirmation.component';


@NgModule({
  declarations: [
    EmailConfirmationComponent
  ],
  imports: [
    CommonModule,
    EmailConfirmationRoutingModule
  ]
})
export class EmailConfirmationModule { }
