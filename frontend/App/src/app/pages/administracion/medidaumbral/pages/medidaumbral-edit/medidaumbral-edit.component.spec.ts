import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedidaumbralEditComponent } from './medidaumbral-edit.component';

describe('MedidaumbralEditComponent', () => {
  let component: MedidaumbralEditComponent;
  let fixture: ComponentFixture<MedidaumbralEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MedidaumbralEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MedidaumbralEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
