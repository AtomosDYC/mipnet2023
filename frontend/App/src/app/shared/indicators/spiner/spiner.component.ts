import { Component, OnInit } from '@angular/core';
import { Colors } from '@coreui/angular-pro'
import { Border } from '@coreui/angular-pro/lib/utilities/border.type';

@Component({
  selector: 'app-spinner',
  templateUrl: './spiner.component.html',
  styleUrls: ['./spiner.component.scss']
})
export class SpinerComponent implements OnInit {

  color: Colors = 'primary';
  variant: Border = 'grow';

  constructor() { }

  ngOnInit(): void {
  }

}
