import { Component, OnInit } from '@angular/core';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as fromList from '../../store/save';
import { RolResponse } from '../../store/save';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-roles-list',
  templateUrl: './roles-list.component.html',
  styleUrls: ['./roles-list.component.scss']
})
export class RolesListComponent implements OnInit {

  Roles$! : Observable<RolResponse[] | null>;
  listadatos : any;
  loading$! : Observable<boolean | null>;
  public selectedItems: any;

  loadingData = false;

  columns = [

    {
      key: 'name',
      label: 'Nombre',
      _style: { width: '90%' }
    }
  ];

  constructor(
    private store: Store<fromRoot.State>,
    private _Route: Router,
    private route: ActivatedRoute,
    ) {

    }

  ngOnInit(): void {

    console.log('roles');
    this.store.dispatch(new fromList.Read());
    this.loading$ = this.store.pipe(select(fromList.getLoading))!;
    this.Roles$ = this.store.pipe(select(fromList.getRoles));
    console.log(this.Roles$);
  }

}
