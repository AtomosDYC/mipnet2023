import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';


@Component({
  selector: 'app-tipopersona-nuevo',
  templateUrl: './tipopersona-nuevo.component.html',
  styleUrls: ['./tipopersona-nuevo.component.scss']
})
export class TipopersonaNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  public tipopersonaForm: FormGroup;

  constructor(private fb: FormBuilder,
    private store: Store<fromRoot.State>)
  {

  }

  ngOnInit(): void {
    this.tipopersonaForm = this.fb.group({
      nombre: ['', Validators.required ],
      descripcion: ['', Validators.required ]
    });
  }

  onguardarNuevo(): void {

    const { nombre, descripcion } = this.tipopersonaForm.value;

    this.loading$ = this.store.pipe(select(fromList.getLoading));

        const tipopersonaCreateRequest : fromList.TipoPersonaCreateRequest = {
          per03nombre : nombre,
          per03descripcion : descripcion
        }

        console.log('tipopersona create request',tipopersonaCreateRequest);

        this.store.dispatch(new fromList.Create(tipopersonaCreateRequest));

  }

}
