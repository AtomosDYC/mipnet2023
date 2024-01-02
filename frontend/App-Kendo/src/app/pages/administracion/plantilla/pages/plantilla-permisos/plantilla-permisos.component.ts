import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from './store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { PlantillaflujoResponse as Response, PlantillaflujoCreateRequest as Request } from './store/save';
import { ActivatedRoute, Router } from '@angular/router';

import { FillComboService } from '../../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../../models/backend/getselect/index';

import { FillPlantillaflujoService } from '../../../../../services/fill-plantillaflujo.service';


import { Employee, employees } from "./Employee";

@Component({
  selector: 'app-plantilla-permisos',
  templateUrl: './plantilla-permisos.component.html',
  styleUrls: ['./plantilla-permisos.component.scss']
})
export class PlantillaPermisosComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  data: Response[];
  success$ !: Observable<boolean | null>;
  Error$ !: Observable<string | null>;
  
  public Form: FormGroup;
  public ID: string | null;
  private _fillcomboservices;
  public customMsgService: CustomMessagesService;

  listdata :  Response  = {
    Prf04Llave: 0,
    Prf03Llave: 0,
    Wkf01Llave: 0,
    wkf01llavepadre: 0,
    wkf01nombre: '',
    prf03nombre: ''
  }

  Tipoflujolist :any;
  Nivelflujolist :any;
  Workflowlist :any;

  errorMessage: any;

  setTipoFlujo: SetSelect = {
    tablename : 'tipo_flujo'
  }
  setNivelFlujo: SetSelect = {
    tablename : 'nivel_flujo',
    prm1 : ''
  }
  setWorkflow: SetSelect = {
    tablename : 'workflow',
    prm1 : ''
  }

  private _FillPlantillaflujoService;

  constructor(private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    public intl: IntlService, 
    public messages: MessageService,
    private _routeParams: ActivatedRoute,
    FillComboService: FillComboService,
    FillPlantillaflujoService: FillPlantillaflujoService
    )
  {
    this.customMsgService = this.messages as CustomMessagesService;
    this._fillcomboservices = FillComboService;
    this._FillPlantillaflujoService = FillPlantillaflujoService;
  }

  ngOnInit(): void {




    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      this.onLoadcbx();

      if(this.ID) {

        

        
      }

      this.Form = new FormGroup({
        cbxTipoflujo: new FormControl(null, Validators.required),
        cbxNivelflujo: new FormControl(null, Validators.required),
        cbxWorkflow: new FormControl(null, [Validators.required])
      });

    });
    
  }



  onLoadcbx():void {

    this._FillPlantillaflujoService.Getdata(Number(this.ID)).subscribe(
      allrecords => {
        this.data = allrecords        
      },
      error => this.errorMessage = <any>error
    );

    this._fillcomboservices.GetAllSelect(this.setTipoFlujo).subscribe(
      allrecords => {
        this.Tipoflujolist = allrecords
        
      },
      error => this.errorMessage = <any>error
    );

  }

  onLoadNivelflujocbx(id: number):void {

    this.setNivelFlujo.prm1 = String(id);

      this._fillcomboservices.GetAllSelect(this.setNivelFlujo).subscribe(
        allrecords => {
          this.Nivelflujolist = allrecords
        },
        error => this.errorMessage = <any>error
      );

  }

  onLoadNodopadrecbx(id: number):void {

    this.setWorkflow.prm1 = String(id);
      this._fillcomboservices.GetAllSelect(this.setWorkflow).subscribe(
        allrecords => {
          this.Workflowlist = allrecords
          //console.log('allrecords', allrecords);
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
      this.Workflowlist = [];
    
    } else {

      this.onLoadNodopadrecbx(value.value);

    }

  }

  onguardarNuevoPermiso(): void {

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { cbxWorkflow  } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {

            Prf03Llave: Number(this.ID),
            Wkf01Llave: cbxWorkflow.value,
           
          }

          this.store.dispatch(new fromList.Create(CreateRequest));

          this.success$ = this.store.pipe(select(fromList.getSuccess));



          this.success$.subscribe((success) => { 

            //console.log("dentro del ssuccess", success);

            if(success) {

              //console.log('dentro del success');

              this.Form = new FormGroup({
                cbxTipoflujo: new FormControl(null, Validators.required),
                cbxNivelflujo: new FormControl(null, Validators.required),
                cbxWorkflow: new FormControl(null, [Validators.required])
              });

              this.onLoadcbx();

            }
          })

          
          
        
      }
    }
  }

  OnDelete(id: number){
    
    if (confirm("Esta seguro de eliminar este tipo de flujo de plantilla?"))
    {
      this.store.dispatch(new fromList.Delete(id.toString()));
    }

  }


}