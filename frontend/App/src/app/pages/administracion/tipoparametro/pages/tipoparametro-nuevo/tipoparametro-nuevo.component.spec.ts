import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoparametroNuevoComponent } from './tipoparametro-nuevo.component';

describe('TipoparametroNuevoComponent', () => {
  let component: TipoparametroNuevoComponent;
  let fixture: ComponentFixture<TipoparametroNuevoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TipoparametroNuevoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TipoparametroNuevoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
