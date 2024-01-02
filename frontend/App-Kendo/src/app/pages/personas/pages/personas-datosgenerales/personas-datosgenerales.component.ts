import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { empty, Observable, tap, Subject } from 'rxjs';

import * as fromRoot from '../../../../store';
import * as fromList from '../../store/save';

import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';

import { ActivatedRoute, Router } from '@angular/router';

import { PersonaResponse as Response } from '../../store/save';
import { PersonaRequest as Request, PersonaRequestUpdate as RequestUpdate } from '../../store/save';

import * as moment from 'moment';

import { FillComboService } from '../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../models/backend/getselect/index';

import { RutService } from 'rut-chileno';

import  { calcularVerificador } from '../../../../_helpers/rut';



@Component({
  selector: 'app-personas-datosgenerales',
  templateUrl: './personas-datosgenerales.component.html',
  styleUrls: ['./personas-datosgenerales.component.scss']
})
export class PersonasDatosgeneralesComponent implements OnInit {

  loading$ !: Observable<boolean | null>;

  VisibleRut: number = 4;
  rutnovalido:boolean =  false;
  
  
  public Form: FormGroup = new FormGroup({
    cbxTipopersona: new FormControl(null, Validators.required),
    cbxTitulo: new FormControl(null, Validators.required),
    cbxTipodocumento: new FormControl(null, Validators.required),
    txtdni: new FormControl( '' ),
    txtpasaporte: new FormControl( '' ),
    txtrut: new FormControl( '' ),
    txtNombre: new FormControl( '' , [Validators.required]),
    txtAlias: new FormControl( '' ),
    txtGirocomercial: new FormControl( '' ),
    txtCargo: new FormControl( '' ),
    txtFechanaciemiento: new FormControl(null),

  });

  public ID: string | null;
  private _fillcomboservices;

  public isDisabledNivelflujo = true;
  public isDisabledContinuarDG = true;

  errorMessage: any;

  public customMsgService: CustomMessagesService;

  Tipopersonalist :any;
  Titulolist :any;
  Tipodocumentolist :any;

  setTipopersona: SetSelect = {
    tablename : 'Tipo_persona'
  }
  setTitulo: SetSelect = {
    tablename : 'saludos'
  }
  setTipodocumento: SetSelect = {
    tablename : 'tipo_documento'
  }

  constructor(
    private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    private _Route: Router,
    public intl: IntlService, 
    public messages: MessageService,
    private _routeParams: ActivatedRoute,
    FillComboService: FillComboService,
    private rutService: RutService
  ) {
    this.customMsgService = this.messages as CustomMessagesService;
    this._fillcomboservices = FillComboService;
   }

  ngOnInit(): void {
    
    this.onLoadcbx();

    this.Form = new FormGroup({
      cbxTipopersona: new FormControl(null, Validators.required),
      cbxTitulo: new FormControl(null, Validators.required),
      cbxTipodocumento: new FormControl(null, Validators.required),
      txtpasaporte: new FormControl( '' ),
      txtdni: new FormControl( null ),
      txtrut: new FormControl( null ),
      txtNombre: new FormControl( null , [Validators.required]),
      txtAlias: new FormControl( null ),
      txtGirocomercial: new FormControl( null ),
      txtCargo: new FormControl( null ),
      txtFechanaciemiento: new FormControl(null),

    });

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        this.isDisabledContinuarDG = false;

        this.store.dispatch(new fromList.GetPersonabyid(this.ID));

        this.loading$ = this.store.pipe(select(fromList.getLoading))!;

        this.store.pipe(select(fromList.getPersonabyid))
          .subscribe(data => {
            if(data){

              let digitoverificador = ''; 
              let rutiformat : string | boolean | undefined = ''; 
              let rut;
              let dni;
              let pasaporte;

              this.VisibleRut = data.per08llave;
              if(data.per08llave==1)
              {

                if(data.per01rut){
                  digitoverificador =  calcularVerificador(data.per01rut.toString());
                }

                //console.log('rut completo', data.per01rut.toString()+digitoverificador);

                rutiformat = this.rutService.getRutChile(0 , data.per01rut.toString()+digitoverificador);
                
                if(!rutiformat){
                  this.rutnovalido = true;
                } else {
                  
                  rut = this.rutService.getRutChileForm(1, rutiformat.toString());
                }

              } 
              else if(data.per08llave==2) 
              {
                dni = data.per01rut;

              } 
              else if(data.per08llave==3) 
              {
                pasaporte = data.per01rut;
              } 
              else 
              {

              }

             
            

              this.Form = new FormGroup({
                cbxTipopersona: new FormControl({value: String(data.per03llave), description: String(data.per03nombre)}, Validators.required),
                cbxTitulo: new FormControl({value: String(data.per02llave), description: String(data.per02nombre)}, Validators.required),
                cbxTipodocumento: new FormControl({value: String(data.per08llave), description: String(data.per08nombre)}, Validators.required),
                txtrut: new FormControl( rut ),
                txtdni: new FormControl( dni ),
                txtpasaporte: new FormControl( pasaporte ),
                txtNombre: new FormControl( data.per01nombrerazon , [Validators.required]),
                txtAlias: new FormControl( data.per01nombrefantasia ),
                txtGirocomercial: new FormControl( data.per01giro ),
                txtCargo: new FormControl( data.per01cargo ),
                txtFechanaciemiento: new FormControl(data.per01fechanacimiento),
          
              });

              /*
                this.Form = new FormGroup({
                  cbxTipoespecie: new FormControl({value: String(data.esp08llave), description: String(data.esp08nombre)}, Validators.required),
                  txtNombre: new FormControl(data.esp03nombre, Validators.required),
                  txtDescripcion: new FormControl( data.esp03descripcion , [Validators.required]),
                  chxUnirespecie: new FormControl(esunion),
                });
*/
            } else {
              
            }
          })
      } 
    });
    
  }

  inputBlur(): void {
    this.rutnovalido = false;
    const { txtrut } = this.Form.value;
    let out4_rut = this.rutService.validaRUT(txtrut);
    if(out4_rut){
      this.rutnovalido = true;
      return;
    }
    let rut = this.rutService.getRutChileForm(1, txtrut)
    this.Form.patchValue({
      txtrut: rut
   });
    
  }

  handleTipodocumentoChange(value) {

    this.VisibleRut = value.value;

  }


  onLoadcbx():void {

    this._fillcomboservices.GetAllSelect(this.setTipopersona).subscribe(
      allrecords => {
        this.Tipopersonalist = allrecords    
      },
      error => this.errorMessage = <any>error
    );

    this._fillcomboservices.GetAllSelect(this.setTitulo).subscribe(
      allrecords => {
        this.Titulolist = allrecords    
      },
      error => this.errorMessage = <any>error
    );
    this._fillcomboservices.GetAllSelect(this.setTipodocumento).subscribe(
      allrecords => {
        this.Tipodocumentolist = allrecords    
      },
      error => this.errorMessage = <any>error
    );
      
  }

  onguardardatosgenerales(): void {

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { cbxTipopersona, cbxTitulo , cbxTipodocumento,  txtrut, txtdni, txtpasaporte, txtNombre, txtAlias, txtGirocomercial, txtCargo, txtFechanaciemiento } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

        let rutiformat: string | undefined ;
        let ruti: string | undefined ;

        if(cbxTipodocumento.value == 1) {
          rutiformat = this.rutService.rutClean(txtrut)!;
          //console.log(rutiformat)
          ruti = rutiformat.substring(0, rutiformat.length -1)
          //console.log('rut formateado',ruti);

        } else if(cbxTipodocumento.value == 2){
          ruti = txtdni;
        } else if(cbxTipodocumento.value == 3) {
          ruti = txtpasaporte;
        } else {
    
        } 

          const UpdateRequest : RequestUpdate = {

            per01llave: Number(this.ID),
            per01rut: Number(ruti),
            per03llave: cbxTipopersona.value,
            per08llave: cbxTipodocumento.value,
            per02llave: cbxTitulo.value,
            per01nombrerazon: String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            per01nombrefantasia: String(txtAlias).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            per01giro: String(txtGirocomercial).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            per01cargo: String(txtCargo).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            per01fechanacimiento: txtFechanaciemiento,
          
          }

          //console.log(UpdateRequest);
          
          this.store.dispatch(new fromList.UpdatePersona(UpdateRequest));

      } else {
      
        const { cbxTipopersona, cbxTitulo , cbxTipodocumento,  txtrut, txtNombre, txtAlias, txtGirocomercial, txtCargo, txtFechanaciemiento  } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {
            
            per01rut: Number(txtrut),
            per03llave: cbxTipopersona.value,
            per08llave: cbxTipodocumento.value,
            per02llave: cbxTitulo.value,
            per01nombrerazon: String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            per01nombrefantasia: String(txtAlias).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            per01giro: String(txtGirocomercial).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            per01cargo: String(txtCargo).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            per01fechanacimiento: txtFechanaciemiento,
            per01anioingreso: moment().year()
          }
          
          //console.log(CreateRequest);

          this.store.dispatch(new fromList.CreatePersona(CreateRequest));
        
      }
    }
    
    
  }
  onContinuar() {
    if(this.ID){
      this._Route.navigate(['/dashboard/personas/datoscomunicacion/', this.ID]);
    }
  }

}
