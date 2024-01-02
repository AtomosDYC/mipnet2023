import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { empty, Observable, tap } from 'rxjs';

import * as fromRoot from '../../../../store';
import * as fromList from '../../store/save';
import * as fromMenu from '../../../../store/menu';
import * as fromLoader from '../../../../store/loader';

import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService, numberSymbols } from '@progress/kendo-angular-intl';

import { ActivatedRoute, Router } from '@angular/router';

import { MonitorResponse as Response,  MonitorRequest as Request, MonitorRequestUpdate as RequestUpdate } from '../../store/save';
import { PersonaResponse as personaResponse, PersonaBuscarRutRequest as PersonaRequest } from '../../store/save';


import { FillComboService } from '../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../models/backend/getselect/index';

import { RutService } from 'rut-chileno';

import  { calcularVerificador } from '../../../../_helpers/rut';
import { getMonitorbyid } from '../../store/save/save.selectors';

@Component({
  selector: 'app-monitor-datosgenerales',
  templateUrl: './monitor-datosgenerales.component.html',
  styleUrls: ['./monitor-datosgenerales.component.scss']
})
export class MonitorDatosgeneralesComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup = new FormGroup(
    {
      cbxTipomonitor: new FormControl (null , Validators.required),
      txtCargo: new FormControl( '' ),
      cbxTipodocumento: new FormControl (null , Validators.required),
      txtrut: new FormControl( '' ),
      txtdni: new FormControl( '' ),
      txtpasaporte: new FormControl( '' ),
      cbxTipopersona: new FormControl (null , Validators.required),
      cbxTitulo: new FormControl (null , Validators.required),
      txtNombre: new FormControl (null , Validators.required),
    }
  );
  public ID: string | null;
  public IDPERSONA: Number | null = 0;

  private _fillcomboservices;

  public isDisabledContinuarDG = false;

  errorMessage: any;

  public customMsgService: CustomMessagesService;

  tipomonitorlist :any;
  Tipodocumentolist :any;
  Tipopersonalist :any;
  Plantillalist: any;
  Titulolist: any;

  

  setTipomonitor: SetSelect = {
    tablename : 'tipo_monitor'
  }

  setTipodocumento: SetSelect = {
    tablename : 'tipo_documento_x_personabuscar'
  }
  setTipoPersona: SetSelect = {
    tablename : 'Tipo_persona'
  }
  setSaludo: SetSelect = {
    tablename : 'saludos'
  }

  VisibleRut: number = 4;
  rutnovalido:boolean =  false;

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
    

    this.store.dispatch(new fromLoader.onsuccess());

    this.onLoadcbx();

    this.Form = new FormGroup(
      {
        cbxTipomonitor: new FormControl (null , Validators.required),
        txtCargo: new FormControl( '' ),
        cbxTipodocumento: new FormControl (null , Validators.required),
        txtrut: new FormControl( '' ),
        txtdni: new FormControl( '' ),
        txtpasaporte: new FormControl( '' ),
        cbxTipopersona: new FormControl (null , Validators.required),
        cbxTitulo: new FormControl (null , Validators.required),
        txtNombre: new FormControl (null , Validators.required),
      }
    );

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {



        this.isDisabledContinuarDG = false;

        this.store.dispatch(new fromList.GetMonitorbyid(this.ID));

        this.loading$ = this.store.pipe(select(fromList.getLoading))!;

        this.store.pipe(select(fromList.getMonitorbyid))
          .subscribe(data => {
            if(data){

              this.IDPERSONA = data.per01llave;

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

                rutiformat = this.rutService.getRutChile(0 , data.per01rut.toString()+digitoverificador);
                
                if(!rutiformat)
                {
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

                cbxTipomonitor: new FormControl ({value: String(data.mnt04llave), description: String(data.mnt04nombre)} , Validators.required),
                txtCargo: new FormControl( data.mnt01Cargo ),
                cbxTipodocumento: new FormControl ({value: String(data.per08llave), description: String(data.per08nombre)}  , Validators.required),
                txtrut: new FormControl( rut ),
                txtdni: new FormControl( dni ),
                txtpasaporte: new FormControl( pasaporte ),
                cbxTipopersona: new FormControl ({value: String(data.per03llave), description: String(data.per08nombre)}, Validators.required),
                cbxTitulo: new FormControl ( {value: String(data.per02llave), description: String(data.per02nombre)} , Validators.required),
                txtNombre: new FormControl ( data.per01nombrerazon , Validators.required),

              });

            } else {
              
            }
          })
      } 
    });

    this.store.dispatch(new fromLoader.cambiarestado());
    
  }

  handleTipodocumentoChange(value) {

    this.VisibleRut = value.value;

  }

  inputBlur(): void {

    const { cbxTipodocumento } = this.Form.value;

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

    let rutiformat: string | undefined ;
    let ruti: string | undefined ;

    if(cbxTipodocumento.value == 1) {
      rutiformat = this.rutService.rutClean(txtrut)!;
      ruti = rutiformat.substring(0, rutiformat.length -1)

      const buscador: PersonaRequest = {
        per01rut: Number(ruti),
        per08llave: 1
      }

      this.store.dispatch(new fromList.GetMonitorbyrut(buscador));
      this.loading$ = this.store.pipe(select(fromList.getLoading))!;

      this.store.pipe(select(fromList.getMonitorbyrut))
        .subscribe(data => {
          if(data){

            this.Form.patchValue({
              txtNombre: data.per01nombrerazon,
              cbxTipopersona: {value: String(data.per03llave), description: String(data.per03nombre)},
              cbxTitulo: {value: String(data.per02llave), description: String(data.per02nombre)}
              
            });

          }
        })
    }
    
    
  }

  onLoadcbx():void {

    this._fillcomboservices.GetAllSelect(this.setTipomonitor).subscribe(
      allrecords => {
        this.tipomonitorlist = allrecords    
      },
      error => this.errorMessage = <any>error
    );

    this._fillcomboservices.GetAllSelect(this.setTipodocumento).subscribe(
      allrecords => {
        this.Tipodocumentolist = allrecords    
      },
      error => this.errorMessage = <any>error
    );
  
    this._fillcomboservices.GetAllSelect(this.setTipoPersona).subscribe(
      allrecords => {
        this.Tipopersonalist = allrecords    
      },
      error => this.errorMessage = <any>error
    );

    this._fillcomboservices.GetAllSelect(this.setSaludo).subscribe(
      allrecords => {
        this.Titulolist = allrecords    
      },
      error => this.errorMessage = <any>error
    );

  }

  onguardardatosgenerales(): void {

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { cbxTipomonitor, txtCargo , cbxTipodocumento,  txtrut, txtdni, txtpasaporte,  cbxTipopersona, cbxTitulo, txtNombre  } = this.Form.value;

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

        const savedata : RequestUpdate = {
          mnt01llave : Number(this.ID),
          per01llave : Number(this.IDPERSONA),
          mnt01Cargo : String(txtCargo).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          mnt04llave : cbxTipomonitor.value,
          per01nombrerazon: String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          per01rut : Number(ruti),
          per02llave: cbxTitulo.value,
          per03llave : cbxTipopersona.value,
          per08llave : cbxTipodocumento.value
        }

        //console.log(savedata);

        
        this.store.dispatch(new fromList.UpdateMonitor(savedata));

      } else {


      
        const { cbxTipomonitor, txtCargo , cbxTipodocumento,  txtrut, txtdni, txtpasaporte,  cbxTipopersona, cbxTitulo, txtNombre  } = this.Form.value;

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

        const UpdateRequest : Request = {
          per01llave : Number(this.IDPERSONA),
          mnt01Cargo : String(txtCargo).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          mnt04llave : cbxTipomonitor.value,
          per01nombrerazon: String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          per01rut : Number(ruti),
          per02llave: cbxTitulo.value,
          per03llave : cbxTipopersona.value,
          per08llave : cbxTipodocumento.value
        }

        //console.log(UpdateRequest);

        
        this.store.dispatch(new fromList.CreateMonitor(UpdateRequest));
        
      }
    }
    
  }
  onContinuarDG() {
    if(this.ID){
      this._Route.navigate(['/dashboard/monitor/datoscomunicacion/', this.ID]);
    }
  }

  OnFinalizarDatosGenerales() 
  {
    this.store.dispatch(new fromMenu.MenuExpanded(true));
    this._Route.navigate(['/dashboard/monitor/list']);

  }

}

