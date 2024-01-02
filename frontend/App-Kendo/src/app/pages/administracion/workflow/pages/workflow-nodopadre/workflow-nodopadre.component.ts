import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { empty, Observable, tap } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';

import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';

import { ActivatedRoute, Router } from '@angular/router';

import { WorkflowResponse as Response } from '../../store/save';
import { WorkflowNodopadreRequest as Request } from '../../store/save';

import { FillComboService } from '../../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../../models/backend/getselect/index';
import { ComboBoxModule } from '@progress/kendo-angular-dropdowns';


@Component({
  selector: 'app-workflow-nodopadre',
  templateUrl: './workflow-nodopadre.component.html',
  styleUrls: ['./workflow-nodopadre.component.scss']
})
export class WorkflowNodopadreComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string | null;
  private _fillcomboservices;

  public isDisabledNivelflujo = true;
 
  public selectedTipoFLujo;
  public selectedNodoPadre;

  errorMessage: any;

  public customMsgService: CustomMessagesService;

  Tipoflujolist :any;
  Nivelflujolist :any;
  Nodopadrelist :any;

  setTipoFlujo: SetSelect = {
    tablename : 'tipo_flujo'
  }
  setNivelFlujo: SetSelect = {
    tablename : 'nivel_flujo',
    prm1 : ''
  }
  setNodoPadre: SetSelect = {
    tablename : 'workflow_nodopadre',
    prm1 : ''
  }

  constructor(
    private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    public intl: IntlService, 
    public messages: MessageService,
    private _routeParams: ActivatedRoute,
    FillComboService: FillComboService,
  ) {
    this.customMsgService = this.messages as CustomMessagesService;
    this._fillcomboservices = FillComboService;
   }

  ngOnInit(): void {

    this.Form = new FormGroup({
      cbxTipoflujo: new FormControl(null, Validators.required),
      cbxNivelflujo: new FormControl(null, Validators.required),
      cbxNodopadre: new FormControl(null, [Validators.required])
    });

    this.onLoadcbx();

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        this.store.dispatch(new fromList.Getbyid(this.ID));

        this.loading$ = this.store.pipe(select(fromList.getLoading))!;
        this.store.pipe(select(fromList.getWorkflowbyid))
          .subscribe(data => {
            if(data){

              this.onLoadNivelflujocbx(data.wkf02llavepadre);
              //console.log('dentro del init nivelflujo', data.wkf03llavepadre)

              this.onLoadNodopadrecbx(data.wkf01llavepadre);
              //console.log('dentro del init 03', data.wkf01llavepadre)


              this.Form = new FormGroup({
                cbxTipoflujo: new FormControl({value: String(data.wkf02llavepadre), description: String(data.wkf02llavepadrenombre)}, Validators.required),
                cbxNivelflujo: new FormControl({value: String(data.wkf03llavepadre), description: String(data.wkf03llavepadrenombre)}, Validators.required),
                cbxNodopadre: new FormControl( {value: String(data.wkf01llavepadre), description: String(data.wkf01llavepadrenombre)} , [Validators.required]),
              });

            }
          })
        }
      });

    

  }

  onLoadcbx():void {

    this._fillcomboservices.GetAllSelect(this.setTipoFlujo).subscribe(
      allrecords => {
        this.Tipoflujolist = allrecords
        
      },
      error => this.errorMessage = <any>error
    );

  }

  onLoadNivelflujocbx(id: number):void {

    this.setNivelFlujo.prm1 = String(id);

    //console.log('this.setNivelFlujo',this.setNivelFlujo);

      this._fillcomboservices.GetAllSelect(this.setNivelFlujo).subscribe(
        allrecords => {
          this.Nivelflujolist = allrecords;
          //console.log('nivelflujocbx', allrecords);
        },
        error => this.errorMessage = <any>error
      );

  }

  onLoadNodopadrecbx(id: number):void {

    this.setNodoPadre.prm1 = String(id);
      this._fillcomboservices.GetAllSelect(this.setNodoPadre).subscribe(
        allrecords => {
          this.Nodopadrelist = allrecords
          //console.log('nodo padre', allrecords);
        },
        error => this.errorMessage = <any>error
      );

  }

  handleTipoFlujoChange(value) {

    if (value === undefined) {

      this.Form.patchValue({ 'cbxNivelflujo': null});
      this.Nivelflujolist = [];

    } else {
      this.onLoadNivelflujocbx(value.value);
    }

  }

  handleNivelflujoChange(value) {

    if (value === undefined) {

      this.Form.patchValue({ 'cbxNodopadre': null});
      this.Nodopadrelist = [];
    
    } else {

      this.onLoadNodopadrecbx(value.value);

    }

  }

  onguardarNuevo(): void {

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { cbxNodopadre } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {
            
            wkf01llave : Number(this.ID),
            wkf01llavepadre: cbxNodopadre.value
        
          }

          //console.log(CreateRequest);
          
          this.store.dispatch(new fromList.UpdateNodopadre(CreateRequest));
        
      }
    }
  }

}
