import { Component, OnInit } from '@angular/core';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as fromList from '../../store/save';
import { TipoPersonaResponse } from '../../store/save';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-tipopersona-list',
  templateUrl: './tipopersona-list.component.html',
  styleUrls: ['./tipopersona-list.component.scss']
})
export class TipopersonaListComponent implements OnInit {

  tipopersonas$! : Observable<TipoPersonaResponse[] | null>;
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
      key: 'per03nombre',
      label: 'Tipo Persona',
      _style: { width: '42%' }
    },
    {
      key: 'per03descripcion',
      label: 'Descripcion',
      _style: { width: '42%' }
    },
    {
      key: 'per03activo',
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
    this.tipopersonas$ = this.store.pipe(select(fromList.getTipoPersonas));
  }

  checkSelected = (selectedItems: any) => {
    this.selectedItems = [].concat(selectedItems);
  };

  onEditar(id: number): void {
    this._Route.navigate(['/dashboard/tipopersona/edit/', id.toString()]);
  }

  onEliminar(id: number, estado : number): void {

    if(estado == 0){
      if (confirm("Esta seguro de eliminar este Tipo de Persona?"))
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


  OndisableTipoPersona():void {

    if(this.selectedItems){

      this.store.dispatch(new fromList.Desactivate(this.selectedItems!));
    }

  }

  onactivateTipoPersona():void {

    if(this.selectedItems){
      this.store.dispatch(new fromList.Activate(this.selectedItems!));
    }
  }
}
