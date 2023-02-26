import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipopermisoNuevoComponent } from './tipopermiso-nuevo.component';

describe('TipopermisoNuevoComponent', () => {
  let component: TipopermisoNuevoComponent;
  let fixture: ComponentFixture<TipopermisoNuevoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TipopermisoNuevoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TipopermisoNuevoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
