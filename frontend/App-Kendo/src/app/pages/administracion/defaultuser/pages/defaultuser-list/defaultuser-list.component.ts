import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { empty, Observable, tap } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { DefaultUserResponse as Response } from '../../store/save';
import { DefaultUserCreateRequest as Request } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';

import { FillComboService } from '../../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../../models/backend/getselect/index';

@Component({
  selector: 'app-defaultuser-list',
  templateUrl: './defaultuser-list.component.html',
  styleUrls: ['./defaultuser-list.component.scss']
})
export class DefaultuserListComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string | null;
  private _fillcomboservices;

  Rollist :any = [
    {value: 'a03610c1-bc39-4a6d-9071-6e1884508aa4', description: 'Usuario'},
    {value: 'baaf5b71-10a3-4bd2-9c2f-9cdbf061fc9c', description: 'Administrador'},
    {value: 'f28554fe-2432-477b-85e3-6f620335fb85', description: 'Visitante'}];
  TipoDocumentolist :any;
  TipoPersonalist :any;
  Plantillalist: any;
  Saludolist: any;

  errorMessage: any;

  setTipoDocumento: SetSelect = {
    tablename : 'tipo_documento'
  }

  setTipoPersona: SetSelect = {
    tablename : 'Tipo_persona'
  }
  setPlantilla: SetSelect = {
    tablename : 'plantilla'
  }
  setSaludo: SetSelect = {
    tablename : 'saludos'
  }
  

  public customMsgService: CustomMessagesService;

  listdata :  Response  = {
    per09llave: 0,
    per09nombre: '',
    rolid: 0,
    tipodocumentoid: 0,
    tipopersonaid: 0,
    plantillaid: 0,
    saludoid: 0
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
      txtNombre: new FormControl( '' , [Validators.required]),
      cbxRol: new FormControl(null, Validators.required),
      cbxTipodocumento: new FormControl(null, Validators.required),
      cbxTipopersona: new FormControl(null, Validators.required),
      cbxPlantilla: new FormControl(null, Validators.required),
      cbxSaludo: new FormControl(null, Validators.required),
    });

    this.store.dispatch(new fromList.Read());
    this.loading$ = this.store.pipe(select(fromList.getLoading))!;
    this.store.pipe(select(fromList.getDefaultUsers))
    .subscribe(data => {

        //console.log("data", data);

      if(data){

          this.ID = String(data.per09llave);

          this.Form = new FormGroup({
            txtNombre: new FormControl( data.per09nombre , [Validators.required]),
            cbxRol: new FormControl({value: String(data.rolid), description: String(data.rolnombre)}, Validators.required),
            cbxTipodocumento: new FormControl({value: String(data.tipodocumentoid), description: String(data.tipodocumentonombre)}, Validators.required),
            cbxTipopersona: new FormControl({value: String(data.tipopersonaid), description: String(data.tipopersonanombre)}, Validators.required),
            cbxPlantilla: new FormControl({value: String(data.plantillaid), description: String(data.plantillanombre)}, Validators.required),
            cbxSaludo: new FormControl({value: String(data.saludoid), description: String(data.saludonombre)}, Validators.required),
          });

      } else {
        this.Form = new FormGroup({
          txtNombre: new FormControl( '' , [Validators.required]),
          cbxRol: new FormControl(null, Validators.required),
          cbxTipodocumento: new FormControl(null, Validators.required),
          cbxTipopersona: new FormControl(null, Validators.required),
          cbxPlantilla: new FormControl(null, Validators.required),
          cbxSaludo: new FormControl(null, Validators.required),
        });    
      }
    });

    

    this.onLoadcbx();

   // this.Form.get('cbxNivelflujo')?.disable();

  }

  onLoadcbx():void {

    
    this._fillcomboservices.GetAllSelect(this.setTipoDocumento).subscribe(
      allrecords => {
        this.TipoDocumentolist = allrecords
        
      },
      error => this.errorMessage = <any>error
    );

    this._fillcomboservices.GetAllSelect(this.setTipoPersona).subscribe(
      allrecords => {
        this.TipoPersonalist = allrecords
        
      },
      error => this.errorMessage = <any>error
    );

    this._fillcomboservices.GetAllSelect(this.setSaludo).subscribe(
      allrecords => {
        this.Saludolist = allrecords
        
      },
      error => this.errorMessage = <any>error
    );

    this._fillcomboservices.GetAllSelect(this.setPlantilla).subscribe(
      allrecords => {
        this.Plantillalist = allrecords
        
      },
      error => this.errorMessage = <any>error
    );
    
     
  }

  onguardarNuevo(): void {

    this.Form.markAllAsTouched();

    //console.log('this.Form.markAllAsTouched()', this.Form.markAllAsTouched());

    if(this.Form.valid){

      if(this.ID){


        //console.log('this.ID', this.ID);

        const { txtNombre, cbxRol, cbxTipopersona, cbxTipodocumento, cbxSaludo, cbxPlantilla } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {

            per09nombre: String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            rolid: cbxRol.value,
            tipodocumentoid: cbxTipodocumento.value,
            tipopersonaid: cbxTipopersona.value,
            plantillaid: cbxPlantilla.value,
            saludoid: cbxSaludo.value
           
          }

          this.store.dispatch(new fromList.Create(CreateRequest));
        
      } else {

        const { txtNombre, cbxRol, cbxTipopersona, cbxTipodocumento, cbxSaludo, cbxPlantilla } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {

            per09nombre: String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            rolid: cbxRol.value,
            tipodocumentoid: cbxTipodocumento.value,
            tipopersonaid: cbxTipopersona.value,
            plantillaid: cbxPlantilla.value,
            saludoid: cbxSaludo.value
           
          }

          //console.log('CreateRequest', CreateRequest);

          this.store.dispatch(new fromList.Create(CreateRequest));

      }
    }

  }

}