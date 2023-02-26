import { Component, OnInit } from '@angular/core';
import { Observable, take } from 'rxjs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Store, select } from '@ngrx/store';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';
import { TipoPersonasResponse, TipoPersonaResponse } from '../../store/save';

@Component({
  selector: 'app-tipopersona-edit',
  templateUrl: './tipopersona-edit.component.html',
  styleUrls: ['./tipopersona-edit.component.scss']
})
export class TipopersonaEditComponent implements OnInit {

  tipopersonaModel$ !: Observable<TipoPersonaResponse | null>;
  loading$ !: Observable<boolean | null>;
  public tipopersonaForm: FormGroup;
  TipopersonaID: string | null;

  tipopersona :  TipoPersonaResponse  = {
    per03llave: 0,
    per03nombre: '',
    per03descripcion: '',
    per03activo: 0
  }

  constructor(private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    private _routeParams: ActivatedRoute,
    private router: Router,)
  {

  }

  ngOnInit(): void {

    this.tipopersonaForm = this.fb.group({
      nombre: ['', Validators.required ],
      descripcion: ['', Validators.required ],
    });

    this._routeParams.paramMap.subscribe(params => {
      this.TipopersonaID = (params.get('id'));

      if(this.TipopersonaID) {
        this.store.dispatch(new fromList.Getbyid(this.TipopersonaID));

      } else {
        this.router.navigate((['/dashboard/tipopersona/list/']));
      }
    })

    this.loading$ = this.store.pipe(select(fromList.getLoading))!;
    this.store.pipe(select(fromList.getTipoPersonabyid))
              .subscribe(data => {
                if(data){
                 this.tipopersonaForm.setValue({
                    nombre: data.per03nombre,
                    descripcion: data.per03descripcion
                  })
                } else {
                  this.router.navigate((['/dashboard/tipopersona/list/']));
                }
              })




  }


  onguardarNuevo(): void {

    console.log('dentro del onguardar');

    const { nombre, descripcion, orden } = this.tipopersonaForm.value;

    this.loading$ = this.store.pipe(select(fromList.getLoading));

        const tipopersonaResponse : fromList.TipoPersonaResponse = {
          per03llave : Number(this.TipopersonaID),
          per03nombre : nombre,
          per03descripcion : descripcion,
          per03activo : 0
        }

        console.log(`create onguardar ${tipopersonaResponse}`);

        this.store.dispatch(new fromList.Update(tipopersonaResponse));

  }

}
