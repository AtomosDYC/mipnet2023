import { Component, OnInit } from '@angular/core';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as fromList from '../../store/save';
import { TipoPerComunicacionResponse } from '../../store/save';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { FillComboService } from '../../../../../services/fill-combo.service';
import { TipoPerComunicacion } from '../../../../../models/backend/tipopercomunicacion/index';
import { SetSelect, GetSelect } from '../../../../../models/backend/getselect/index';
import { TipoComPersona } from '../../../../../models/backend/tipocompersona/index';
import { TipoPerComunicacionCreateRequest } from '../../store/save/save.models';

@Component({
  selector: 'app-tipopercomunicacion-list',
  templateUrl: './tipopercomunicacion-list.component.html',
  styleUrls: ['./tipopercomunicacion-list.component.scss']
})
export class TipopercomunicacionListComponent implements OnInit {

  tipopercomunicaciones$! : Observable<TipoPerComunicacionResponse[] | null>;
  listadatos : any;
  loading$! : Observable<boolean | null>;
  TipoPreComunicacionID: string | null;
  private _fillcomboservices;

  TipoComunicacionlist :GetSelect[];
  TipoPersonalist :GetSelect[];

  setTipoPersona: SetSelect = {
    tablename : 'Tipo_Persona_x_tipo_comunicacion'
  }

  setTipoComunicacion: SetSelect = {
    tablename : 'Tipo_Comunicacion_persona'
  }

  errorMessage: any;

  public selectedItems: any;

  public tipopercomunicacionForm: FormGroup;

  loadingData = false;

  columns = [

    {
      key: 'show',
      label: '',
      _style: { width: '7%' },
      filter: false,
      sorter: false
    },
    {
      key: 'per04nombre',
      label: 'Nombre',
      _style: { width: '43%' }
    },
    {
      key: 'per03nombre',
      label: 'descripción',
      _style: { width: '43%' }
    }

  ];

  constructor(
    private store: Store<fromRoot.State>,
    private _Route: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private _routeParams: ActivatedRoute,
    FillComboService: FillComboService,
    ) {
      this._fillcomboservices = FillComboService;
    }

  ngOnInit(): void {

    this._routeParams.paramMap.subscribe(params => {
      this.TipoPreComunicacionID = (params.get('id'));
    })

    if(this.TipoPreComunicacionID) {

      console.log('dentro del tipo DE COMUNICACION', this.TipoPreComunicacionID);

      this.store.dispatch(new fromList.Getbyid(this.TipoPreComunicacionID));

      this.loading$ = this.store.pipe(select(fromList.getLoading))!;

      this.tipopercomunicaciones$ = this.store.pipe(select(fromList.getTipoPerComunicaciones));

      this.tipopercomunicacionForm = this.fb.group({
        tipocomunicacion:  new FormControl({value: 'Seleccione Tipo Comunicación', disabled: true}, Validators.required),
        tipopersona: new FormControl({value:'Seleccione Tipo Persona', disabled: false}, Validators.required)
      });

      this.onLoadcbx();

    }
  }

  onLoadcbx():void {

    if(this.TipoPreComunicacionID) {

      console.log('dentro DEL ONLOAD', this.TipoPreComunicacionID);

      this._fillcomboservices.GetAllSelect(this.setTipoComunicacion).subscribe(
        allrecords => {
          this.TipoComunicacionlist = allrecords
        },
        error => this.errorMessage = <any>error
      );

      this.tipopercomunicacionForm.setValue({
        tipocomunicacion: Number(this.TipoPreComunicacionID),
        tipopersona: ''
      })

      this.setTipoPersona.prm1 = this.TipoPreComunicacionID;

      console.log(this.setTipoPersona);

      this._fillcomboservices.GetAllSelect(this.setTipoPersona).subscribe(
        allrecords => {
          this.TipoPersonalist = allrecords
        },
        error => this.errorMessage = <any>error
      );

    }

  }

  onguardarNuevo(): void {

    const { tipopersona } = this.tipopercomunicacionForm.value;

    this.loading$ = this.store.pipe(select(fromList.getLoading));

        const request : fromList.TipoPerComunicacionCreateRequest = {
          per04llave : Number(this.TipoPreComunicacionID),
          per03llave : tipopersona
        }

        console.log('request',request);

        this.store.dispatch(new fromList.Create(request));

        this.onLoadcbx();

  }

  onEliminar(id: number): void {


    const request: TipoPerComunicacionCreateRequest = {
      per03llave: Number(id),
      per04llave: Number(this.TipoPreComunicacionID)
    }

    console.log(request, 'request');

    if (confirm("Esta seguro de eliminar la persona asociada al tipo de comunicación?"))
    {
      this.store.dispatch(new fromList.Delete(request));

      this.onLoadcbx();

    }

  }

}
