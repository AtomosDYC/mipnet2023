import { Component, OnInit } from '@angular/core';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';

import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as fromRoot from '../../../../../store';
import * as fromList from '../../store/save';

import { MessageService } from '@progress/kendo-angular-l10n';
import { CustomMessagesService } from 'src/app/services/custom-messages.service';
import { IntlService } from '@progress/kendo-angular-intl';
import { ActivatedRoute } from '@angular/router';

import { NodeClickEvent } from '@progress/kendo-angular-treeview';
import { DrawerItem, DrawerSelectEvent } from '@progress/kendo-angular-layout';


@Component({
  selector: 'app-tipocompersona-nuevo',
  templateUrl: './tipocompersona-nuevo.component.html',
  styleUrls: ['./tipocompersona-nuevo.component.scss']
})
export class TipocompersonaNuevoComponent implements OnInit {

  loading$ !: Observable<boolean | null>;

  public selected = "Tipo Comunicacion";
  
  public Form: FormGroup;
  public ID: string | null;

  public customMsgService: CustomMessagesService;

  constructor(
    private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    public intl: IntlService, 
    public messages: MessageService,
    private _routeParams: ActivatedRoute,
  ) {
    this.customMsgService = this.messages as CustomMessagesService;
   }

   public items: Array<DrawerItem> = [
    { text: "Tipo Comunicacion", id: "1", selected: true },
    { text: "Asociar con Persona", id:"2", disabled: true },
  ];

  ngOnInit(): void {

    this._routeParams.paramMap.subscribe(params => {
      this.ID = (params.get('id'));

      if(this.ID) 
      {
        this.items = [
          { text: "Tipo Comunicacion", id: "1", selected: true },
          { text: "Asociar con Persona", id:"2", disabled: false },
        ];

        

      } else {
        this.items = [
          { text: "Tipo Comunicacion", id: "1", selected: true },
          { text: "Asociar con Persona", id:"2", disabled: true },
        ];
        
        this.Form = new FormGroup({
          txtNombre: new FormControl('' , [Validators.required]),
          txtDescripcion: new FormControl('', [Validators.required])
        });

      }

    });

  }

  public events: string[] = [];

  public isSingleClicked = false;

  public onSelect(ev: DrawerSelectEvent): void {
    this.selected = ev.item.text;
  }

}
