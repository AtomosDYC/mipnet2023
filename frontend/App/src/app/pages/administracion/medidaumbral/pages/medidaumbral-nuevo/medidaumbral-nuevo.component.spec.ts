import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedidaumbralNuevoComponent } from './medidaumbral-nuevo.component';

describe('MedidaumbralNuevoComponent', () => {
  let component: MedidaumbralNuevoComponent;
  let fixture: ComponentFixture<MedidaumbralNuevoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MedidaumbralNuevoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MedidaumbralNuevoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
