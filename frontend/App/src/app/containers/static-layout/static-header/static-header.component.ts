import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-static-header',
  templateUrl: './static-header.component.html',
  styleUrls: ['./static-header.component.scss']
})
export class StaticHeaderComponent {

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

}
