import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-static-header',
  templateUrl: './static-header.component.html',
  styleUrls: ['./static-header.component.scss']
})
export class StaticHeaderComponent {

  @Output() public toggle = new EventEmitter();
  @Input() public selectedPage?: string;


  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  

  public onButtonClick(): void {
    this.toggle.emit();
} 

}
