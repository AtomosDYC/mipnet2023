import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { empty, Observable, tap } from 'rxjs';

import * as fromRoot from '../../../../store';
import * as fromList from '../../store/save';

import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';

import { ActivatedRoute, Router } from '@angular/router';

import { MonitorResponse as Response } from '../../store/save';
import { MonitorRequest as Request } from '../../store/save';

import { FillComboService } from '../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../models/backend/getselect/index';

@Component({
  selector: 'app-monitor-mover',
  templateUrl: './monitor-mover.component.html',
  styleUrls: ['./monitor-mover.component.scss']
})
export class MonitorMoverComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup = new FormGroup(
    {
      cbxTipoespecie: new FormControl(null, Validators.required),
      txtNombre: new FormControl(null, Validators.required),
      txtDescripcion: new FormControl( null , [Validators.required]),
      chxUnirespecie: new FormControl(null),
    }
  );
  public ID: string | null;
  private _fillcomboservices;

  public isDisabledContinuarMT = false;

  errorMessage: any;

  public customMsgService: CustomMessagesService;


  constructor(
    private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    private _Route: Router,
    public intl: IntlService, 
    public messages: MessageService,
    private _routeParams: ActivatedRoute,
    FillComboService: FillComboService,
  ) {
    this.customMsgService = this.messages as CustomMessagesService;
    this._fillcomboservices = FillComboService;
   }

  ngOnInit(): void {
    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {
      }
    });
  }


  onguardardatosgenerales(): void {

  }
  onContinuarMT() {
    if(this.ID){
      this._Route.navigate(['/dashboard/monitor/datoscelulares/', this.ID]);
    }
  }

}