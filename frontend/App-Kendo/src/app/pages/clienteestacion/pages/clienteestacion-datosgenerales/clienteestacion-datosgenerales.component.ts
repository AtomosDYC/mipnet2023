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

import { ClienteEstacionResponse as Response,  ClienteEstacionRequest as Request, ClienteEstacionRequestUpdate as RequestUpdate } from '../../store/save';

import { FillComboService } from '../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../models/backend/getselect/index';

import { RutService } from 'rut-chileno';

import  { calcularVerificador } from '../../../../_helpers/rut';
import { request } from 'http';

@Component({
  selector: 'app-clienteestacion-datosgenerales',
  templateUrl: './clienteestacion-datosgenerales.component.html',
  styleUrls: ['./clienteestacion-datosgenerales.component.scss']
})
export class ClienteestacionDatosgeneralesComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup = new FormGroup(
    {
      cbxTipocliente: new FormControl (null , Validators.required),
      txtrut: new FormControl (null , Validators.required),
      cbxTitulo: new FormControl (null , Validators.required),
      txtNombre: new FormControl (null , Validators.required),
      txtNombrefantasia: new FormControl (null),
    }
  );
  public ID: string | null;
  public IDPERSONA: Number | null = 0;

  private _fillcomboservices;

  public isDisabledContinuarDG = false;

  errorMessage: any;

  public customMsgService: CustomMessagesService;

  tipoclientelist :any;
  Titulolist: any;

  setTipocliente: SetSelect = {
    tablename : 'Tipo_Cliente'
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
        cbxTipocliente: new FormControl (null , Validators.required),
        txtrut: new FormControl ('' , Validators.required),
        cbxTitulo: new FormControl (null , Validators.required),
        txtNombre: new FormControl ('', Validators.required),
        txtNombrefantasia: new FormControl (''),
      }
    );

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        this.isDisabledContinuarDG = false;

        this.store.dispatch(new fromList.GetClienteEstacionbyid(this.ID));

        this.loading$ = this.store.pipe(select(fromList.getLoading))!;

        this.store.pipe(select(fromList.getClienteEstacionbyid))
          .subscribe(data => {
            if(data){
              
              this.IDPERSONA = Number(data.per01llave);

              let digitoverificador = ''; 
              let rutiformat : string | boolean | undefined = ''; 
              let rut;
              let dni;
              let pasaporte;

              
              if(data.per01rut){
                digitoverificador =  calcularVerificador(data.per01rut.toString());
              }

              rutiformat = this.rutService.getRutChile(0 , Number(data.per01rut).toString()+digitoverificador);
                
              if(!rutiformat)
              {
                this.rutnovalido = true;
              } else {
                rut = this.rutService.getRutChileForm(1, rutiformat.toString());
              }

              this.Form.patchValue({
                cbxTipocliente: {value: String(data.cnt03llave), description: String(data.cnt03nombre)},
                txtrut: rut,
                cbxTitulo: {value: String(data.per02llave), description: String(data.per02titulo)},
                txtNombre: data.cnt01nombre,
                txtNombrefantasia: data.per01nombrefantasia,
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

    rutiformat = this.rutService.rutClean(txtrut)!;
    ruti = rutiformat.substring(0, rutiformat.length -1)

      console.log('ruti',ruti);
      this.store.dispatch(new fromList.GetClienteEstacionbyrut(ruti));
      this.loading$ = this.store.pipe(select(fromList.getLoading))!;


      this.store.pipe(select(fromList.getClienteEstacionbyrut))
        .subscribe(data => {
          if(data){

            console.log('data',data);

            this.Form.patchValue({
              cbxTipocliente: {value: String(data.cnt03llave), description: String(data.cnt03nombre)},
              cbxTitulo: {value: String(data.per02llave), description: String(data.per02titulo)},
              txtNombre: data.cnt02nombre,
              txtNombrefantasia: data.per01nombrefantasia,
            });

            this.ID = String(data.cnt01llave);
            this.IDPERSONA = Number(data.per01llave);
            
          }
        })
    
    
  }

  onLoadcbx():void {

    this._fillcomboservices.GetAllSelect(this.setTipocliente).subscribe(
      allrecords => {
        this.tipoclientelist = allrecords    
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

        const { cbxTipocliente, txtrut , cbxTitulo,  txtNombre, txtNombrefantasia  } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

        let rutiformat: string | undefined ;
        let ruti: string | undefined ;

        rutiformat = this.rutService.rutClean(txtrut)!;
          //console.log(rutiformat)
        ruti = rutiformat.substring(0, rutiformat.length -1)
        
        const RequestUpdateData : RequestUpdate = {
          cnt01llave: Number(this.ID),
          cnt01nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          cnt03llave : cbxTipocliente.value,
          per01nombrefantasia: String(txtNombrefantasia).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          per01rut : Number(ruti),
          per02llave: cbxTitulo.value,
        }
        
        this.store.dispatch(new fromList.UpdateClienteEstacion(RequestUpdateData));
        

      } else {

        const { cbxTipocliente, txtrut , cbxTitulo,  txtNombre, txtNombrefantasia  } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

        let rutiformat: string | undefined ;
        let ruti: string | undefined ;

        rutiformat = this.rutService.rutClean(txtrut)!;
          //console.log(rutiformat)
        ruti = rutiformat.substring(0, rutiformat.length -1)

        const Request : Request = {
          cnt01nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          cnt03llave : cbxTipocliente.value,
          per01nombrefantasia: String(txtNombrefantasia).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          per01rut : Number(ruti),
          per02llave: cbxTitulo.value,
        }

        console.log(Request);

        this.store.dispatch(new fromList.CreateClienteEstacion(Request));
        
      }
    }
    
  }
  onContinuarDG() {
    if(this.ID){
      this._Route.navigate(['/dashboard/clienteestacion/datoscomunicacion/', this.ID]);
    }
  }

  OnFinalizarDatosGenerales() 
  {
    this.store.dispatch(new fromMenu.MenuExpanded(true));
    this._Route.navigate(['/dashboard/clienteestacion/list']);

  }

}
