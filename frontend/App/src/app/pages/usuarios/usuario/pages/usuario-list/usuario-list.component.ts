import { Component, OnInit } from '@angular/core';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as fromList from '../../store/save';
import { UsuarioResponse } from '../../store/save';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-usuario-list',
  templateUrl: './usuario-list.component.html',
  styleUrls: ['./usuario-list.component.scss']
})
export class UsuarioListComponent implements OnInit {

  usuarios$! : Observable<UsuarioResponse[] | null>;
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
      key: 'userName',
      label: 'Username',
      _style: { width: '53%' }
    },
    {
      key: 'email',
      label: 'Email',
      _style: { width: '40%' }
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
    this.usuarios$ = this.store.pipe(select(fromList.getUsuarios));

    console.log(this.usuarios$)
  }

  checkSelected = (selectedItems: any) => {
    this.selectedItems = [].concat(selectedItems);
  };

  onEditar(id: number): void {
    //this._Route.navigate(['/dashboard/usuario/edit/', id.toString()]);
  }

  onEliminar(id: number, estado : number): void {

    if(estado == 0){
      if (confirm("Esta seguro de eliminar esta región?"))
      {
        //this.store.dispatch(new fromList.Delete(id.toString()));
      }
    } else {
      //this.store.dispatch(new fromList.Delete(id.toString()));
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


  OndisableUsuario():void {

    if(this.selectedItems){

      //this.store.dispatch(new fromList.Desactivate(this.selectedItems!));
    }

  }

  onactivateUsuario():void {

    if(this.selectedItems){
      //this.store.dispatch(new fromList.Activate(this.selectedItems!));
    }

  }

}
