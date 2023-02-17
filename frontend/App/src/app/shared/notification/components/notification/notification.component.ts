import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import * as fromvisibleToast from '../../../../store/notification/notification.actions';

import { visibleToast } from '../../../../store/notification';
import { State } from '../../../../store';


@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.scss']
})
export class NotificationComponent implements OnInit {

  visualizarToast = false;
  visible:boolean = false
  position = 'top-end';
  percentage = 0;
  title = 'Notificacion Mipnet';
  contenido= 'sin definir';
  type = 'info';

  visibleToast: visibleToast = {visible: false, mensaje: '', type: 'info'};

  constructor(private store:Store<State>) {  }

  ngOnInit(): void {

    this.store.select('visibleToast')
      .subscribe( visibleToast => this.visible = visibleToast.visible);

      this.store.select('visibleToast')
      .subscribe( visibleToast => this.contenido = visibleToast.mensaje);

      this.store.select('visibleToast')
      .subscribe( visibleToast => this.type = visibleToast.type);

  }

  onclick() {

    this.store.dispatch(fromvisibleToast.visualizar({toast: {visible:true, mensaje: 'dentro del click', type:'info'}}));

  }


  onVisibleChange($event: boolean) {
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
