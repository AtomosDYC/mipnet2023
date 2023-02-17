import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastModule, ProgressModule } from '@coreui/angular-pro';
import { NotificationComponent } from './notification.component';

@NgModule({
  declarations: [
    NotificationComponent
  ],
  imports: [
    CommonModule,
    ToastModule,
    ProgressModule,
  ],
  exports: [
    NotificationComponent
  ]
})
export class NotificationModule { }
