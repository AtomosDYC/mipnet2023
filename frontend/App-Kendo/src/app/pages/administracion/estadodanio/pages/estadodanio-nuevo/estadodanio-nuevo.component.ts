import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { EstadoDanioResponse as Response } from '../../store/save';
import { EstadoDanioCreateRequest as Request } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';

import { FillComboService } from '../../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../../models/backend/getselect/index';
import { getEstadoDaniobyid } from '../../store/save/save.selectors';

@Component({
  selector: 'app-estadodanio-nuevo',
  templateUrl: './estadodanio-nuevo.component.html',
  styleUrls: ['./estadodanio-nuevo.component.scss']
})
export class EstadodanioNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string | null;
  private _fillcomboservices;

  MedidaUmbrallist : Observable<GetSelect[] | null>;
  errorMessage: any;

  setMedidaUmbral : SetSelect = {
    tablename : 'Medida_umbral'
  }

  public customMsgService : CustomMessagesService;

  listdata :  Response  = {
    esp04llave: 0,
    esp04activo: 0,
    esp04nombre: '',
    esp04descripcion: '',
    esp06llave: 0,
    esp06nombre:''
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
      txtNombre: new FormControl( this.listdata.esp04nombre , [Validators.required]),
      txtDescripcion: new FormControl(this.listdata.esp04descripcion, [Validators.required]),
      cbxMedidaumbral: new FormControl({ text: this.listdata.esp06nombre, value: this.listdata.esp06llave }, [Validators.required]),
      
    });

    this.onLoadcbx();

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        this.store.dispatch(new fromList.Getbyid(this.ID));

        this.loading$ = this.store.pipe(select(fromList.getLoading))!;
        this.store.pipe(select(fromList.getEstadoDaniobyid))
          .subscribe(data => {
            if(data){

              //console.log('data',data);

              this.Form = new FormGroup({
                txtNombre: new FormControl( data.esp04nombre , [Validators.required]),
                txtDescripcion: new FormControl(data.esp04descripcion, [Validators.required]),
                cbxMedidaumbral: new FormControl({value: String(data.esp06llave), description: String(data.esp06nombre)}, [Validators.required]),
              });

            } else {
              
            }
          })
      }

      

    });
    
  }

  onLoadcbx():void {

    this._fillcomboservices.GetAllSelect(this.setMedidaUmbral).subscribe(
      allrecords => {
        this.MedidaUmbrallist = allrecords
      },
      error => this.errorMessage = <any>error
    );

  }

  onguardarNuevo(): void {

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { txtNombre, txtDescripcion, cbxMedidaumbral } = this.Form.value;

        
        const DataResponse : Response = {
          esp04llave : Number(this.ID),
          esp04nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          esp04descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          esp06llave: cbxMedidaumbral.value,
          esp04activo: 1,
          esp06nombre:''
        }

        this.store.dispatch(new fromList.Update(DataResponse));

      } else {
      
        const { txtNombre, txtDescripcion, cbxMedidaumbral } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {
            esp04nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            esp04descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            esp06llave: cbxMedidaumbral.value,
          }

          
          this.store.dispatch(new fromList.Create(CreateRequest));

      }
    }
  }
}