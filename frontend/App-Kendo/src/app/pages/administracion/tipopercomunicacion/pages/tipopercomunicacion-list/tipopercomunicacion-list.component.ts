import { Component, OnInit, Input } from '@angular/core';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';

import * as fromList from '../../store/save';
import { TipoPerComunicacionResponse as Response } from '../../store/save';
import { Router, ActivatedRoute } from '@angular/router';

import { IntlService } from '@progress/kendo-angular-intl';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { FillComboService } from '../../../../../services/fill-combo.service';
import { SetSelect, GetSelect } from '../../../../../models/backend/getselect/index';
import { TipoPerComunicacionCreateRequest } from '../../store/save/save.models';

@Component({
  selector: 'app-tipopercomunicacion-list',
  templateUrl: './tipopercomunicacion-list.component.html',
  styleUrls: ['./tipopercomunicacion-list.component.scss']
})
export class TipopercomunicacionListComponent implements OnInit {

  @Input() ID: string | null;

  public Form: FormGroup;
  loading$ !: Observable<boolean | null>;
  success$ !: Observable<boolean | null>;
  Error$ !: Observable<string | null>;
  data$! : Observable<Response[] | null>;
  listadatos : any;
  private _fillcomboservices;

  TipoPersonalist :Observable<GetSelect[] | null>;
  errorMessage: any;

  setTipoPersona: SetSelect = {
    tablename : 'Tipo_Persona_x_tipo_comunicacion'
  }

  public selectedItems: any;
  public mySelection: string[] = [];
  public filtro:string = '';

  public customMsgService: CustomMessagesService;

  constructor(
    private store: Store<fromRoot.State>,
    private _Route: Router,
    public intl: IntlService, 
    public messages: MessageService,
    FillComboService: FillComboService,
    ) {
      this.customMsgService = this.messages as CustomMessagesService;
      this._fillcomboservices = FillComboService;
    }

  ngOnInit(): void {

    if(this.ID) 
    {
    
      this.Form = new FormGroup({
        cmbTipopersona: new FormControl(null, [Validators.required]),
      });

      this.store.dispatch(new fromList.Getbyid(this.ID));
      this.loading$ = this.store.pipe(select(fromList.getLoading))!;
      this.data$ = this.store.pipe(select(fromList.getTipoPerComunicaciones));
    }
    this.onLoadcbx();

  }

  onLoadcbx():void {

    if(this.ID) {

      this.setTipoPersona.prm1 = this.ID;

      this._fillcomboservices.GetAllSelect(this.setTipoPersona).subscribe(
        allrecords => {
          this.TipoPersonalist = allrecords
        },
        error => this.errorMessage = <any>error
      );

    }

  }


  onAgregar(): void {

    this.Form.markAllAsTouched();
    
    this.loading$ = this.store.pipe(select(fromList.getLoading));

    const { cmbTipopersona } = this.Form.value;

    const request : fromList.TipoPerComunicacionCreateRequest = {
      per04llave : Number(this.ID),
      per03llave : cmbTipopersona.value
    }

    this.store.dispatch(new fromList.Create(request));

    this.success$ = this.store.pipe(select(fromList.getSuccess));

    this.success$.subscribe((success) => { 
      if(success) {

        this.Form.reset();
        this.onLoadcbx();
      }
    })
    
  }

  onFinalizar():void {

    this._Route.navigate(['/dashboard/tipocomunicacionpersona/list/']);

  }

  onEliminar(id: number): void {

    const request: TipoPerComunicacionCreateRequest = {
      per03llave: Number(id),
      per04llave: Number(this.ID)
    }

    if (confirm("Esta seguro de eliminar la persona asociada al tipo de comunicación?"))
    {
      this.store.dispatch(new fromList.Delete(request));

      this.success$ = this.store.pipe(select(fromList.getSuccess));

      this.success$.subscribe((success) => { 
        if(success) {

          this.onLoadcbx();
        }
      })

    }

  }

  

}
