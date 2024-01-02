import { Component, OnInit } from '@angular/core';

import { DomSanitizer } from '@angular/platform-browser';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';

import * as fromList from './store/save';
import { WorkflowParametroResponse as Response, WorkflowParametroRequest as Request } from './store/save';
import { Router, ActivatedRoute } from '@angular/router';

import { IntlService } from '@progress/kendo-angular-intl';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { DataStateChangeEvent } from "@progress/kendo-angular-grid";
import { getWorkflowParametros, getWorkflowParametrobyid } from './store/save/save.selectors';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';


import { FillComboService } from '../../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../../models/backend/getselect/index';


@Component({
  selector: 'app-workflow-parametros',
  templateUrl: './workflow-parametros.component.html',
  styleUrls: ['./workflow-parametros.component.scss']
})
export class WorkflowParametrosComponent implements OnInit {

  data$! : Observable<Response[] | null>;
  success$ !: Observable<boolean | null>;
  Error$ !: Observable<string | null>;

  listadatos : any;
  loading$! : Observable<boolean | null>;
  Tipoparametrolist: any;

  public verNuevo: boolean = false;
  public ID: string | null;
  private _fillcomboservices;

  public Form: FormGroup = new FormGroup({
    cbxTipoparametro: new FormControl( null , [Validators.required]),
    txtVariable: new FormControl(null, [Validators.required]),
    txtValor: new FormControl(null, [Validators.required]),
  });

  public selectedItems: any;
  public mySelection: string[] = [];
  public filtro:string = '';
  errorMessage: any;

  setTipoparametro: SetSelect = {
    tablename : 'Tipo_parametro'
  }

  public customMsgService: CustomMessagesService;

  constructor(
    private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    private _routeParams: ActivatedRoute,
    public intl: IntlService, 
    public messages: MessageService,
    FillComboService: FillComboService,
    ) {
      this.customMsgService = this.messages as CustomMessagesService;
      this._fillcomboservices = FillComboService;
    }

  onLoadcbx():void {

    this._fillcomboservices.GetAllSelect(this.setTipoparametro).subscribe(
      allrecords => {
        this.Tipoparametrolist = allrecords
      },
      error => this.errorMessage = <any>error
    );
  }

  ngOnInit(): void {

    this.onLoadcbx();

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        this.store.dispatch(new fromList.Read(this.ID));
        this.loading$ = this.store.pipe(select(fromList.getLoading))!;
        this.data$ =  this.store.pipe(select(fromList.getWorkflowParametros));
  

        this.Form = new FormGroup({
          cbxTipoparametro: new FormControl( null , [Validators.required]),
          txtVariable: new FormControl(null, [Validators.required]),
          txtValor: new FormControl(null, [Validators.required]),
        });

      }
    });
  }

  OnNuevo(){

    this.verNuevo = true;

  }

  OnCancelar(){

    this.verNuevo = false;
    
  }

  onguardarNuevo(){

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { cbxTipoparametro, txtVariable , txtValor } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const UpdateRequest : Request = {
            
            wkf01llave: Number(this.ID),
            wkf10llave: cbxTipoparametro.value,
            wkf09variable: String(txtVariable).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            wkf09valor: String(txtValor).toLowerCase().replace(/^\w/, (c) => c.toUpperCase())

          }

          this.store.dispatch(new fromList.Create(UpdateRequest));

          this.success$ = this.store.pipe(select(fromList.getSuccess));

          //console.log('this.success$', this.success$);

          this.success$.subscribe((success) => { 
            if(success) {

              this.verNuevo = false;

            }
          })

      }
    }
  }
  
  OnEliminar(id: number){
        this.store.dispatch(new fromList.Delete(id.toString()));
    
  }

  
}
