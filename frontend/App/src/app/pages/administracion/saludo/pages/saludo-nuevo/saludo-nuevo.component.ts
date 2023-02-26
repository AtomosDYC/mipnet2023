import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';

@Component({
  selector: 'app-saludo-nuevo',
  templateUrl: './saludo-nuevo.component.html',
  styleUrls: ['./saludo-nuevo.component.scss']
})
export class SaludoNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;
  public saludoForm: FormGroup;

  constructor(private fb: FormBuilder,
    private store: Store<fromRoot.State>)
  {

  }

  ngOnInit(): void {
    this.saludoForm = this.fb.group({
      titulo: ['', Validators.required ],
      orden: ['', Validators.required ],
    });
  }

  onguardarNuevo(): void {

    const { titulo, orden } = this.saludoForm.value;

    this.loading$ = this.store.pipe(select(fromList.getLoading));

        const saludoCreateRequest : fromList.SaludoCreateRequest = {
          per02titulo : titulo,
          per02orden: Number(orden),
        }

        this.store.dispatch(new fromList.Create(saludoCreateRequest));
  }
}
