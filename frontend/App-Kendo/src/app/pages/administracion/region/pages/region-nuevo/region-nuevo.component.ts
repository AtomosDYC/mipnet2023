import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { RegionResponse } from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-region-nuevo',
  templateUrl: './region-nuevo.component.html',
  styleUrls: ['./region-nuevo.component.scss']
})
export class RegionNuevoComponent implements OnInit {
  loading$ !: Observable<boolean | null>;
  
  public regionForm: FormGroup;
  public RegionID: string | null;

  public customMsgService: CustomMessagesService;

  region :  RegionResponse  = {
    sist04llave: 0,
    sist04nombre: 'nombre',
    sist04descripcion: 'descripcion',
    sist04orden: 0,
    sist04activo: 0
  }

  constructor(private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    public intl: IntlService, 
    public messages: MessageService,
    private _routeParams: ActivatedRoute,
    private router: Router
    )
  {
    
  }

  ngOnInit(): void {
    this.customMsgService = this.messages as CustomMessagesService;

    this._routeParams.paramMap.subscribe(params => {
      this.RegionID = (params.get('id'));

      //console.log('this.RegionID', this.RegionID);

      if(this.RegionID) {

        //console.log('dentro de this.RegionID', this.RegionID);

        this.store.dispatch(new fromList.Getbyid(this.RegionID));

        this.loading$ = this.store.pipe(select(fromList.getLoading))!;
        this.store.pipe(select(fromList.getRegionbyid))
          .subscribe(data => {
            if(data){

              //console.log('dentro del subcribe', this.RegionID);

                this.regionForm = new FormGroup({
                  txtNombre: new FormControl( data.sist04nombre , [Validators.required]),
                  txtDescripcion: new FormControl(data.sist04descripcion, [Validators.required]),
                  txtOrden: new FormControl(data.sist04orden, [Validators.required])
                });

            } else {
              
            }
          })
      }

      this.regionForm = new FormGroup({
        txtNombre: new FormControl( this.region.sist04nombre , [Validators.required]),
        txtDescripcion: new FormControl(this.region.sist04descripcion, [Validators.required]),
        txtOrden: new FormControl(this.region.sist04orden, [Validators.required])
      });

    });

    
    //console.log(this.regionForm);
    
  }

  onguardarNuevo(): void {

    this.regionForm.markAllAsTouched();

    if(this.regionForm.valid){

      if(this.RegionID){

        //console.log('dentro del edit');

        const { txtNombre, txtDescripcion, txtOrden } = this.regionForm.value;

        const regionResponse : fromList.RegionResponse = {
          sist04llave : Number(this.RegionID),
          sist04nombre : txtNombre,
          sist04descripcion : txtDescripcion,
          sist04orden: Number(txtOrden),
          sist04activo : 0
        }

        //console.log(`create onupdate ${regionResponse}`);

        this.store.dispatch(new fromList.Update(regionResponse));


      } else {

        //console.log('dentro del onguardar');
      
        const { txtNombre, txtDescripcion, txtOrden } = this.regionForm.value;

        this.loading$ = this.store.pipe(select(fromList.getLoading));

          const regionCreateRequest : fromList.RegionCreateRequest = {
            sist04nombre : txtNombre,
            sist04descripcion : txtDescripcion,
            sist04orden: Number(txtOrden),
          }

          
          this.store.dispatch(new fromList.Create(regionCreateRequest));

      }
    }
  }

}
