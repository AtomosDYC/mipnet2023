import { Component, OnInit } from '@angular/core';

import { DomSanitizer } from '@angular/platform-browser';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';


import * as fromList from '../../store/save';
import { WorkflowResponse as Response } from '../../store/save';

import { Router, ActivatedRoute } from '@angular/router';

import { IntlService } from '@progress/kendo-angular-intl';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';

import {DataStateChangeEvent } from "@progress/kendo-angular-grid";
import { getWorkflows } from '../../store/save/save.selectors';

import { FillWorkflowService } from '../../../../../services/fill-workflow.service';
import { FillComboService } from '../../../../../services/fill-combo.service';

@Component({
  selector: 'app-workflow-list',
  templateUrl: './workflow-list.component.html',
  styleUrls: ['./workflow-list.component.scss']
})

export class WorkflowListComponent implements OnInit {

  data$! : Observable<Response[] | null>;
  data: Response[];
  listadatos : any;
  loading$! : Observable<boolean | null>;
  public selectedItems: any;
  public mySelection: string[] = [];
  public filtro:string = '';
  public errorMessage: any;

  private _fillworkflowService;
  public customMsgService: CustomMessagesService;

  constructor(
    private store: Store<fromRoot.State>,
    private _Route: Router,
    public intl: IntlService, 
    public messages: MessageService,
    FillWorkflowService: FillWorkflowService,
    ) {
      this.customMsgService = this.messages as CustomMessagesService;
      this._fillworkflowService = FillWorkflowService;
    }

  ngOnInit(): void {
    
    this.onLoadcbx();

  }

  onLoadcbx():void {

    this._fillworkflowService.Getdata().subscribe(
      allrecords => {
        this.data = allrecords    
      },
      error => this.errorMessage = <any>error
    );
  }

  OnNuevo(){
    this._Route.navigate(['/dashboard/workflow/datosgenerales/']);
  }

  OnEditar(id: number){
    this._Route.navigate(['/dashboard/workflow/datosgenerales/', id.toString()]);
  }

  OnEliminar(id: number, estado : number){
    
  }

  OndisableRegion():void {

  }

  onactivateRegion():void {

    
  }

 
  

}
