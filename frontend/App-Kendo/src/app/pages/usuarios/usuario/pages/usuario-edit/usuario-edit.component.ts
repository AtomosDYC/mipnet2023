import { Component, OnInit, ViewChild } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { UsuarioResponse as Response, UsuarioRegistroUpdateRequest as request } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';

import { TextBoxComponent } from "@progress/kendo-angular-inputs";

import { FillComboService } from '../../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../../models/backend/getselect/index';
import { Update } from '../../store/save/save.actions';


@Component({
  selector: 'app-usuario-edit',
  templateUrl: './usuario-edit.component.html',
  styleUrls: ['./usuario-edit.component.scss']
})
export class UsuarioEditComponent implements OnInit {

  @ViewChild("password") public textbox: TextBoxComponent;

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string;

  public customMsgService: CustomMessagesService;

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


  constructor(private FormBuilder: FormBuilder,
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

    this.Form = this.FormBuilder.group({
      cbxRol: [null, Validators.required],
      txtNombre: [null, Validators.required],
      email: [null, Validators.compose([Validators.required, Validators.email])],
      cbxSaludo: [null, Validators.required],
      cbxTipodocumento: [null, [Validators.required]],
      cbxTipopersona: [null, [Validators.required]],
      cbxPlantilla: [null, [Validators.required]],
    });

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'))!;

      this.onLoadcbx();

      if(this.ID) {

        this.store.dispatch(new fromList.Getbyid(this.ID));

        this.loading$ = this.store.pipe(select(fromList.getLoading))!;
        this.store.pipe(select(fromList.getUsuarioregistrobyid))
          .subscribe(data => {
            if(data){

              this.Form = this.FormBuilder.group({
                cbxRol: [{value: String(data.roleid), description: String(data.rolename)}, Validators.required],
                txtNombre: [data.per01nombre, Validators.required],
                email: [data.email, Validators.compose([Validators.required, Validators.email])],
                cbxSaludo: [{value: String(data.saludoid), description: String(data.saludonombre)}, Validators.required],
                cbxTipodocumento: [{value: String(data.tipodocumentoid), description: String(data.tipodocumentonombre)}, [Validators.required]],
                cbxTipopersona: [{value: String(data.tipopersonaid), description: String(data.tipopersonanombre)}, [Validators.required]],
                cbxPlantilla: [{value: String(data.plantillaid), description: String(data.plantillanombre)}, [Validators.required]],
              });

            }
      });

      }
    });

    
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
    // stop here if form is invalid

    if(this.Form.valid){
    
      const { cbxRol, txtNombre, email, cbxSaludo, cbxTipodocumento, cbxTipopersona, cbxPlantilla  } = this.Form.value;

      this.loading$ = this.store.pipe(select(fromList.getLoading));

      const CreateRequest : request = {
        userid: this.ID,
        per01nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
        email: email,
        plantillaid: cbxPlantilla.value,
        roleid: cbxRol.value,
        saludoid: cbxSaludo.value,
        tipodocumentoid : cbxTipodocumento.value,
        tipopersonaid: cbxTipopersona.value,
        username : String(email).toLowerCase()
      }

      //console.log('CreateRequest',CreateRequest);
    
      this.store.dispatch(new fromList.Update(CreateRequest));

    }

  }
}