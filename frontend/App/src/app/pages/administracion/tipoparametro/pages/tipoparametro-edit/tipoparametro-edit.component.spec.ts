import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoparametroEditComponent } from './tipoparametro-edit.component';

describe('TipoparametroEditComponent', () => {
  let component: TipoparametroEditComponent;
  let fixture: ComponentFixture<TipoparametroEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TipoparametroEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TipoparametroEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
