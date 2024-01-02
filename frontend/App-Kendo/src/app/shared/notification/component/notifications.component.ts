import { Component, OnInit, TemplateRef } from '@angular/core';
import { Store } from '@ngrx/store';
import * as fromvisibleToast from '../../../store/notification/notification.actions';

import { visibleToast } from '../../../store/notification';
import { State } from '../../../store';
import { NotificationRef, NotificationService } from '@progress/kendo-angular-notification';


@Component({
  selector: 'app-notification',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.scss']
})
export class NotificationsComponent implements OnInit {

  visible:boolean = false
  position = 'top-end';
  percentage = 0;
  title = 'Notificacion Mipnet';
  contenido= 'sin definir';
  type = 'info';

  visibleToast: visibleToast = {visible: false, mensaje: '', type: 'info'};

  public notificationTemplate: TemplateRef<unknown>;
  
  constructor(private store:Store<State>, private notificationService: NotificationService) {  }

  ngOnInit(): void {

    this.store.select('visibleToast')
      .subscribe( 
        visibleToast => { 
         
          //console.log('dentro del mensajero');
          if(visibleToast){
            if(visibleToast.visible){

              const notification: NotificationRef = this.notificationService.show({
                content: visibleToast.mensaje,
                hideAfter: 2500,
                position: { horizontal: "right", vertical: "top" },
                animation: { type: "fade", duration: 1000 },
                type: { style: visibleToast.type, icon: true },
              });

              notification.afterHide?.subscribe(() => this.store.dispatch(fromvisibleToast.CambiarEstado()));

            }
          }
        }
      );
    

  }

  

  public showDefault(): void {
    this.notificationService.show({
      content: "Default notification",
      hideAfter: 1500,
      position: { horizontal: "right", vertical: "top" },
      animation: { type: "fade", duration: 400 },
      type: { style: "none", icon: false },
    });
  }
  public showSuccess(): void {
    this.notificationService.show({
      content: "Notificación de éxito",
      hideAfter: 1500,
      position: { horizontal: "right", vertical: "top" },
      animation: { type: "fade", duration: 400 },
      type: { style: "success", icon: true },
    });
  }
  public showWarning(): void {
    this.notificationService.show({
      content: "Notificación de advertencia",
      hideAfter: 1500,
      position: { horizontal: "right", vertical: "top" },
      animation: { type: "fade", duration: 400 },
      type: { style: "warning", icon: true },
    });
  }
  public showInfo(): void {
    this.notificationService.show({
      content: "Notificación de información",
      hideAfter: 1500,
      position: { horizontal: "right", vertical: "top" },
      animation: { type: "fade", duration: 400 },
      type: { style: "info", icon: true },
    });
  }
  public showError(): void {
    this.notificationService.show({
      content: "Notificación de error",
      hideAfter: 1500,
      position: { horizontal: "right", vertical: "top" },
      animation: { type: "fade", duration: 400 },
      type: { style: "error", icon: true },
    });
  }
  


  onclick() {

    this.store.dispatch(fromvisibleToast.visualizar({toast: {visible:true, mensaje: 'dentro del click', type:'info'}}));

  }


  onVisibleChange($event: boolean) {
    //console.log('visible change');
    this.visible = $event;
    if(!$event){
      this.store.dispatch(fromvisibleToast.CambiarEstado());
    }
    this.percentage = !this.visible ? 0 : this.percentage;
  }

  onTimerChange($event: number) {
    this.percentage = $event * 25;
  }

}
