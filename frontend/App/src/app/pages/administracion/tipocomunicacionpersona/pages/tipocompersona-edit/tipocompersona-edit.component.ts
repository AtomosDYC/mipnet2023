import { Component, OnInit } from '@angular/core';
import { Observable, take } from 'rxjs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Store, select } from '@ngrx/store';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';
import { ActivatedRoute, Router } from '@angular/router';
import { TipoComPersonasResponse, TipoComPersonaResponse } from '../../store/save';

@Component({
  selector: 'app-tipocompersona-edit',
  templateUrl: './tipocompersona-edit.component.html',
  styleUrls: ['./tipocompersona-edit.component.scss']
})
export class TipocompersonaEditComponent implements OnInit {

  tipocompersonaModel$ !: Observable<TipoComPersonaResponse | null>;
  loading$ !: Observable<boolean | null>;
  public tipocompersonaForm: FormGroup;
  TipoComPersonaID: string | null;

  tipocompersona :  TipoComPersonaResponse  = {
    per04llave: 0,
    per04nombre: '',
    per04descripcion: '',
    per04activo: 0
  }

  constructor(private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    private _routeParams: ActivatedRoute,
    private router: Router,)
  {

  }

  ngOnInit(): void {

    this.tipocompersonaForm = this.fb.group({
      nombre: ['', Validators.required ],
      descripcion: ['', Validators.required ]
    });

    this._routeParams.paramMap.subscribe(params => {
      this.TipoComPersonaID = (params.get('id'));

      if(this.TipoComPersonaID) {
        this.store.dispatch(new fromList.Getbyid(this.TipoComPersonaID));

      } else {
        this.router.navigate((['/dashboard/tipocomunicacionpersona/list/']));
      }
    })

    this.loading$ = this.store.pipe(select(fromList.getLoading))!;
    this.store.pipe(select(fromList.getTipoComPersonabyid))
              .subscribe(data => {
                if(data){
                 this.tipocompersonaForm.setValue({
                    nombre: data.per04nombre,
                    descripcion: data.per04descripcion
                  })
                } else {
                 // this.router.navigate((['/dashboard/tipocomunicacionpersona/list/']));
                }
              })
    }


  onguardarNuevo(): void {

    const { nombre, descripcion, orden } = this.tipocompersonaForm.value;

    this.loading$ = this.store.pipe(select(fromList.getLoading));

        const tipocompersonaResponse : fromList.TipoComPersonaResponse = {
          per04llave : Number(this.TipoComPersonaID),
          per04nombre : nombre,
          per04descripcion : descripcion,
          per04activo : 0
        }

        this.store.dispatch(new fromList.Update(tipocompersonaResponse));

  }

}
