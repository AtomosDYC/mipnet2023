import { Component, OnInit } from '@angular/core';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as fromList from '../../store/save';
import { SaludoResponse } from '../../store/save';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-saludo-list',
  templateUrl: './saludo-list.component.html',
  styleUrls: ['./saludo-list.component.scss']
})
export class SaludoListComponent implements OnInit {

  saludos$! : Observable<SaludoResponse[] | null>;
  listadatos : any;
  loading$! : Observable<boolean | null>;
  public selectedItems: any;

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
      key: 'per02titulo',
      label: 'Saludo',
      _style: { width: '80%' }
    },
    {
      key: 'per02orden',
      label: 'Orden',
      _style: { width: '10%' }
    },
    {
      key: 'per02activo',
      label:'',
      _style: { width: '80px' },
      filter: false,
      sorter: false
    }

  ];

  constructor(
    private store: Store<fromRoot.State>,
    private _Route: Router,
    private route: ActivatedRoute,
    ) {

    }

  ngOnInit(): void {
    this.store.dispatch(new fromList.Read());
    this.loading$ = this.store.pipe(select(fromList.getLoading))!;
    this.saludos$ = this.store.pipe(select(fromList.getSaludos));
  }

  checkSelected = (selectedItems: any) => {
    this.selectedItems = [].concat(selectedItems);
  };

  onEditar(id: number): void {
    this._Route.navigate(['/dashboard/saludos/edit/', id.toString()]);
  }

  onEliminar(id: number, estado : number): void {

    if(estado == 0){
      if (confirm("Esta seguro de eliminar este Saludo?"))
      {
        this.store.dispatch(new fromList.Delete(id.toString()));
      }
    } else {
      this.store.dispatch(new fromList.Delete(id.toString()));
    }

  }

  getBadge(status: number) : string {
    switch (status) {
      case 1:
        return 'success';
      case 0:
        return 'danger';
      default:
          return 'success';
    }
  }

  getBadgeestado(status: number) : string {
    switch (status) {
      case 1:
        return 'Activo';
      case 0:
        return 'Desactivado';
      default:
        return 'Activo';
    }
  }


  OndisableSaludo():void {

    if(this.selectedItems){

      this.store.dispatch(new fromList.Desactivate(this.selectedItems!));
    }

  }

  onactivateSaludo():void {

    if(this.selectedItems){
      this.store.dispatch(new fromList.Activate(this.selectedItems!));
    }
  }
}
