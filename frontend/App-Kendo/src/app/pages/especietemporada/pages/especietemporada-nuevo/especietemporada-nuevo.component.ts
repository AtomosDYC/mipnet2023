import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { EspecieTemporadaResponse as Response } from '../../store/save';
import { EspecieTemporadaRequest as Request } from '../../store/save';
import { EspecieTemporadaRequestUpdate as RequestUpdate } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';


import { FillComboService } from '../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../models/backend/getselect/index';
import { getEspecieTemporadabyid } from '../../store/save/save.selectors';

@Component({
  selector: 'app-especietemporada-nuevo',
  templateUrl: './especietemporada-nuevo.component.html',
  styleUrls: ['./especietemporada-nuevo.component.scss']
})
export class EspecietemporadaNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public FormEspecieTemporada: FormGroup = new FormGroup({
    cbxTipoEspecie: new FormControl(null , [Validators.required]),
    cbxEspecie: new FormControl(null, [Validators.required]),
    cbxTipodanio: new FormControl(null , [Validators.required]),
    cbxTemporada: new FormControl(null , [Validators.required]),
    dtpInicio: new FormControl(new Date(), [Validators.required]),
    dtpTermino: new FormControl(new Date(), [Validators.required]),
    chxsag: new FormControl(null),
    chxmexico: new FormControl(null),
  });

  public ID: string | null;

  private _fillcomboservices;

  public selecteBase;
  public selectedSegmentacion;

  errorMessage: any;

  public customMsgService: CustomMessagesService;

  tipoespecielist :any;
  especielist :any;
  tipodaniolist :any;
  temporadalist :any;
  
  setTipoespecie: SetSelect = {
    tablename : 'Tipoespecie_cargadas'
  }
  setEspecie: SetSelect = {
    tablename : 'EspecieBase_cargadas',
    prm1: ''
  }
  setDanio: SetSelect = {
    tablename : 'EspecieDanio_cargadas',
    prm1: ''
  }
  setTemporada: SetSelect = {
    tablename : 'Temporadas_cargadas',
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

    
    this.onLoadcbx();

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        this.store.dispatch(new fromList.GetEspecieTemporadabyid(this.ID));

        this.loading$ = this.store.pipe(select(fromList.getLoadingespecietemporada))!;
        this.store.pipe(select(fromList.getEspecieTemporadabyid))
          .subscribe(data => {
            if(data){

              //console.log('data',data);

              const [dateStr, timeStr] = data.esp02iniciotemporada!.toString().split('T');
              
              const [dateStrmin, timeStrmin] = data.esp02terminotemporada!.toString().split('T');

              const sag = data.esp02sag ? true : false

              const maxico = data.esp02mexico ? true : false

              this.onLoadcbxEspecie(Number(data.esp08llave));
              

              this.onLoadcbxTipoDanio(Number(data.esp03llave));
              
              this.FormEspecieTemporada = new FormGroup({
                cbxTipoEspecie: new FormControl({value: String(data.esp08llave), description: String(data.esp08nombre)} , [Validators.required]),
                cbxEspecie: new FormControl({value: String(data.esp03llave), description: String(data.esp03nombre)}, [Validators.required]),
                cbxTipodanio: new FormControl({value: String(data.esp01llave), description: String(data.esp04nombre)} , [Validators.required]),
                cbxTemporada: new FormControl({value: String(data.temp01llave), description: String(data.temp02nombre)} , [Validators.required]),
                dtpInicio: new FormControl(new Date(dateStr), [Validators.required]),
                dtpTermino: new FormControl(new Date(dateStrmin), [Validators.required]),
                chxsag: new FormControl(sag),
                chxmexico: new FormControl(maxico),

              });

            } else {
              
            }
          })
      }
 
    });
    
  }

  onLoadcbx():void {

    this._fillcomboservices.GetAllSelect(this.setTipoespecie).subscribe(
      allrecords => {0
        this.tipoespecielist = allrecords
        
      },
      error => this.errorMessage = <any>error
    );

    this._fillcomboservices.GetAllSelect(this.setTemporada).subscribe(
      allrecords => {0
        this.temporadalist = allrecords
        
      },
      error => this.errorMessage = <any>error
    );

  }

  handleTipoespecieChange(value) {

    
    if (value === undefined) {

      this.FormEspecieTemporada.patchValue({ 'cbxtipoespecie': null});
      this.tipoespecielist = [];

    } else {

      this.onLoadcbxEspecie(value.value);

    }
  }

  onLoadcbxEspecie(id: number):void {


    this.setEspecie.prm1 = String(id);

    //console.log(this.setEspecie);

    this._fillcomboservices.GetAllSelect(this.setEspecie).subscribe(
      allrecords => {
        this.especielist = allrecords
      },
      error => this.errorMessage = <any>error
    );

  }

  handleEspecieChange(value) {

    
    if (value === undefined) {

      this.FormEspecieTemporada.patchValue({ 'cbxespecie': null});
      this.tipodaniolist = [];

    } else {

      this.onLoadcbxTipoDanio(value.value);

    }
  }

  onLoadcbxTipoDanio(id: number):void {


    this.setDanio.prm1 = String(id);

    //console.log('this.setDanio',this.setDanio);

    this._fillcomboservices.GetAllSelect(this.setDanio).subscribe(
      allrecords => {
        this.tipodaniolist = allrecords
      },
      error => this.errorMessage = <any>error
    );

  }

  onguardarNuevo(): void {
    

    this.FormEspecieTemporada.markAllAsTouched();

    if(this.FormEspecieTemporada.valid){

      if(this.ID){

        const { cbxTipoEspecie, cbxEspecie, cbxTipodanio, cbxTemporada, dtpInicio, dtpTermino, chxsag, chxmexico } = this.FormEspecieTemporada.value;

        const sag = chxsag ? 1 : 0;

        const mexico = chxmexico ? 1 : 0;

        this.loading$ = this.store.pipe(select(fromList.getLoadingespecietemporada));

        const UpdateRequest : RequestUpdate = {
          esp02llave: Number(this.ID),
          esp01llave : cbxTipodanio.value,
          temp01llave : cbxTemporada.value,
          esp02iniciotemporada: dtpInicio,
          esp02terminotemporada : dtpTermino,
          esp02sag : sag,
          esp02mexico :mexico,

        }

        //console.log('temporada', UpdateRequest );
          
        this.store.dispatch(new fromList.UpdateEspecieTemporada(UpdateRequest));
      
      } else {
      
        const { cbxTipoEspecie, cbxEspecie, cbxTipodanio, cbxTemporada, dtpInicio, dtpTermino, chxsag, chxmexico } = this.FormEspecieTemporada.value;

        const sag = chxsag ? 1 : 0;

        const mexico = chxmexico ? 1 : 0;

        this.loading$ = this.store.pipe(select(fromList.getLoadingespecietemporada));

        const CreateRequest : Request = {
          esp01llave : cbxTipodanio.value,
          temp01llave : cbxTemporada.value,
          esp02iniciotemporada: dtpInicio,
          esp02terminotemporada : dtpTermino,
          esp02sag : sag,
          esp02mexico :mexico,

        }

        //console.log('temporada', CreateRequest );
        
        this.store.dispatch(new fromList.CreateEspecieTemporada(CreateRequest));


      }
    }
    
  }
  

}
