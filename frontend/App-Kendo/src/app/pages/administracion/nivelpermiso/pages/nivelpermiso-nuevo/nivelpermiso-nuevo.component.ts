import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { empty, Observable, tap } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { NivelPermisoResponse as Response } from '../../store/save';
import { NivelPermisoCreateRequest as Request } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';

import { FillComboService } from '../../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../../models/backend/getselect/index';

@Component({
  selector: 'app-nivelpermiso-nuevo',
  templateUrl: './nivelpermiso-nuevo.component.html',
  styleUrls: ['./nivelpermiso-nuevo.component.scss']
})
export class NivelpermisoNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string | null;
  private _fillcomboservices;

  Tipoflujolist :any;
  Tipopermisolist :any;
  Nivelflujolist :any;

  private formFieldTipoFlujoValueChanges$: Observable<any>;
  
  public isDisabledNivelflujo = true;
 
  public selectedTipoFLujo;
  
  errorMessage: any;

  setTipoFlujo: SetSelect = {
    tablename : 'tipo_flujo'
  }
  setNivelFlujo: SetSelect = {
    tablename : 'nivel_flujo',
    prm1 : ''
  }
  setTipoPermiso: SetSelect = {
    tablename : 'tipo_permiso'
  }


  public customMsgService: CustomMessagesService;

  listdata :  Response  = {
    wkf04llave: 0,
    wkf03llave: 0,
    wkf03nombre: '',
    wkf05llave: 0,
    wkf05nombre: '',
    wkf04activo: 0,
  }

  constructor(private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    public intl: IntlService, 
    public messages: MessageService,
    private _routeParams: ActivatedRoute,
    FillComboService: FillComboService,
    )
  {
    this.customMsgService = this.messages as CustomMessagesService;
    this._fillcomboservices = FillComboService;
  }

  ngOnInit(): void {

    

    this.Form = new FormGroup({
      cbxTipoflujo: new FormControl(null, Validators.required),
      cbxNivelflujo: new FormControl(null, Validators.required),
      cbxTipopermiso: new FormControl(null, Validators.required)
    });

    this.onLoadcbx();

   // this.Form.get('cbxNivelflujo')?.disable();

  }

  onLoadcbx():void {

    this._fillcomboservices.GetAllSelect(this.setTipoFlujo).subscribe(
      allrecords => {
        this.Tipoflujolist = allrecords
        
      },
      error => this.errorMessage = <any>error
    );
    
    /*

    this.formFieldTipoFlujoValueChanges$ = this.Form
      .get('cbxTipoflujo')!
      .valueChanges.pipe(
        tap((_arrayStates) => {
          //this.Form.patchValue({ cbxNivelflujo: ''});
          return _arrayStates;
        })
      );
    this.formFieldTipoFlujoValueChanges$.subscribe();
      */

    this._fillcomboservices.GetAllSelect(this.setTipoPermiso).subscribe(
      allrecords => {
        this.Tipopermisolist = allrecords
        
      },
      error => this.errorMessage = <any>error
    );

  }

  onguardarNuevo(): void {

    this.Form.markAllAsTouched();
    

    const { cbxNivelflujo, cbxTipopermiso  } = this.Form.value;

   if(this.Form.valid){
      this.loading$ = this.store.pipe(select(fromList.getLoading));

      const CreateRequest : Request = {
        wkf03llave: cbxNivelflujo.value,
        wkf05llave: cbxTipopermiso.value
      }
        
      this.store.dispatch(new fromList.Create(CreateRequest));
    }

  }

  handleNivelflujoChange(value) {

    this.selectedTipoFLujo = value;

    if (value === undefined) {

      this.Form.patchValue({ 'cbxNivelflujo': null});
      this.Nivelflujolist = [];
      
      //this.Form.setValue({ cbxNivelflujo : {text:'' , value:null} })
    
    } else {
    
      this.setNivelFlujo.prm1 = String(value.value);

      this._fillcomboservices.GetAllSelect(this.setNivelFlujo).subscribe(
        allrecords => {
          this.Nivelflujolist = allrecords
        },
        error => this.errorMessage = <any>error
      );
    }

  }

}