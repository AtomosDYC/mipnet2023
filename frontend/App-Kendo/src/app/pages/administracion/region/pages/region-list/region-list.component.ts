import { Component, OnInit } from '@angular/core';

import { DomSanitizer } from '@angular/platform-browser';

import * as fromRoot from '../../../../../store';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import * as fromList from '../../store/save';
import { RegionResponse } from '../../store/save';
import { Router, ActivatedRoute } from '@angular/router';

import { IntlService } from '@progress/kendo-angular-intl';
import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';

@Component({
  selector: 'app-region-list',
  templateUrl: './region-list.component.html',
  styleUrls: ['./region-list.component.scss']
})
export class RegionListComponent implements OnInit {

  regiones$! : Observable<RegionResponse[] | null>;
  listadatos : any;
  loading$! : Observable<boolean | null>;
  public selectedItems: any;
  public mySelection: string[] = [];

  public customMsgService: CustomMessagesService;

  constructor(
    private store: Store<fromRoot.State>,
    private sanitizer: DomSanitizer,
    private _Route: Router,
    private route: ActivatedRoute,
    public intl: IntlService, 
    public messages: MessageService
    ) {
      this.customMsgService = this.messages as CustomMessagesService;
    }


  ngOnInit(): void {
    this.store.dispatch(new fromList.Read());
    this.loading$ = this.store.pipe(select(fromList.getLoading))!;
    this.regiones$ = this.store.pipe(select(fromList.getRegiones));
  }

  OnNuevo(){
    this._Route.navigate(['/dashboard/region/nuevo/']);
  }

  OnEditar(id: number){
    console.log('dentro del click editar');
    this._Route.navigate(['/dashboard/region/edit/', id.toString()]);
  }

  OnEliminar(id: number, estado : number){
    if(estado == 0){
      if (confirm("Esta seguro de eliminar esta región?"))
      {
        this.store.dispatch(new fromList.Delete(id.toString()));
      }
    } else {
      this.store.dispatch(new fromList.Delete(id.toString()));
    }
  }

  OndisableRegion():void {

    
    const request: RegionResponse[] =  this.mySelection.map((item) => {
      const test:RegionResponse = {
        sist04llave: Number(item),
        sist04activo: 1,
        sist04descripcion:'',
        sist04nombre:'',
        sist04orden:0
      };
      return test;
    });

    if(request){
      this.store.dispatch(new fromList.Desactivate(request!));
      this.mySelection = [];
    }

  }

  onactivateRegion():void {

    const request: RegionResponse[] =  this.mySelection.map((item) => {

      const test:RegionResponse = {
        sist04llave: Number(item),
        sist04activo: 1,
        sist04descripcion:'',
        sist04nombre:'',
        sist04orden:0
      };
      return test;
    });

    if(request){
      this.store.dispatch(new fromList.Activate(request!));
      this.mySelection = [];
    }

  }

}
