import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NotificationsComponent } from './notifications.component';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NotificationModule } from "@progress/kendo-angular-notification";
import { ButtonsModule } from '@progress/kendo-angular-buttons';

@NgModule({
  declarations: [
    NotificationsComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    NotificationModule,
    ButtonsModule,
    /*
    CommonModule,
    ToastModule,
    ProgressModule,
    */
  ],
  exports: [
    NotificationsComponent
  ]
})
export class NotificationsModule { }
