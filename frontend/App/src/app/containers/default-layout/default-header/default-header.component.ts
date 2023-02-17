import { outputAst } from '@angular/compiler';
import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

import { ClassToggleService, HeaderComponent } from '@coreui/angular-pro';
import { UserResponse } from '../../../store/user';


@Component({
  selector: 'app-default-header',
  templateUrl: './default-header.component.html',
  styleUrls: ['./default-header.component.scss']
})
export class DefaultHeaderComponent extends HeaderComponent {

  @Input() sidebarId: string = "sidebar";
  @Input() user! : UserResponse | null;
  @Input() isAuthorized! : boolean | null;
  @Output() signOut  = new EventEmitter<void>();

  public newMessages = new Array(4)
  public newTasks = new Array(5)
  public newNotifications = new Array(5)

  constructor(private classToggler: ClassToggleService) {
    super();
  }

  onSignOut():void {
    this.signOut.emit();
  }
}
