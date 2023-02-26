import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NivelpermisoNuevoComponent } from './nivelpermiso-nuevo.component';

describe('NivelpermisoNuevoComponent', () => {
  let component: NivelpermisoNuevoComponent;
  let fixture: ComponentFixture<NivelpermisoNuevoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NivelpermisoNuevoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NivelpermisoNuevoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
