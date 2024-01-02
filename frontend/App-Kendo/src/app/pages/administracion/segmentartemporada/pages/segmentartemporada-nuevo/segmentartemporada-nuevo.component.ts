import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { SegmentarTemporadaResponse as Response } from '../../store/save';
import { SegmentarTemporadasCreaterequest as Request } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-segmentartemporada-nuevo',
  templateUrl: './segmentartemporada-nuevo.component.html',
  styleUrls: ['./segmentartemporada-nuevo.component.scss']
})
export class SegmentartemporadaNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  
  public Form: FormGroup;
  public ID: string | null;

  public customMsgService: CustomMessagesService;

  listdata :  Response  = {
    temp03llave: 0,
    temp03nombre: '',
    temp03descripcion: '',
    temp03activo: 0,
    temp03numeromeses: 0,
    temp03numerosegmentostotal: 0
  }

  constructor(private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    public intl: IntlService, 
    public messages: MessageService,
    private _routeParams: ActivatedRoute,
    )
  {
    this.customMsgService = this.messages as CustomMessagesService;
  }

  ngOnInit(): void {

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) {

        this.store.dispatch(new fromList.Getbyid(this.ID));

        this.loading$ = this.store.pipe(select(fromList.getLoading))!;
        this.store.pipe(select(fromList.getSegmentarTemporadabyid))
          .subscribe(data => {
            if(data){

                this.Form = new FormGroup({
                  txtNombre: new FormControl( data.temp03nombre , [Validators.required]),
                  txtDescripcion: new FormControl(data.temp03descripcion, [Validators.required]),
                  txtnumeromeses: new FormControl(data.temp03numeromeses, [Validators.required]),
                  txtnumerosegmentostotal: new FormControl(data.temp03numerosegmentostotal, [Validators.required])
                });

            } else {
              
            }
          })
      }

      this.Form = new FormGroup({
        txtNombre: new FormControl( this.listdata.temp03nombre , [Validators.required]),
        txtDescripcion: new FormControl(this.listdata.temp03descripcion, [Validators.required]),
        txtnumeromeses: new FormControl(this.listdata.temp03numeromeses, [Validators.required]),
        txtnumerosegmentostotal: new FormControl(this.listdata.temp03numerosegmentostotal, [Validators.required])
      });

    });
    
  }

  onguardarNuevo(): void {

    this.Form.markAllAsTouched();

    if(this.Form.valid){

      if(this.ID){

        const { txtNombre, txtDescripcion, txtnumeromeses, txtnumerosegmentostotal } = this.Form.value;

        const DataResponse : Response = {
          temp03llave : Number(this.ID),
          temp03nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          temp03descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
          temp03numeromeses: Number(txtnumeromeses),
          temp03numerosegmentostotal: Number(txtnumerosegmentostotal),
          temp03activo : 0
        }

        this.store.dispatch(new fromList.Update(DataResponse));

      } else {
      
        const { txtNombre, txtDescripcion, txtnumeromeses, txtnumerosegmentostotal } = this.Form.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const CreateRequest : Request = {
            temp03nombre : String(txtNombre).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            temp03descripcion: String(txtDescripcion).toLowerCase().replace(/^\w/, (c) => c.toUpperCase()),
            temp03numeromeses: Number(txtnumeromeses),
            temp03numerosegmentostotal: Number(txtnumerosegmentostotal),
          }

          
          this.store.dispatch(new fromList.Create(CreateRequest));

      }
    }
  }

}
