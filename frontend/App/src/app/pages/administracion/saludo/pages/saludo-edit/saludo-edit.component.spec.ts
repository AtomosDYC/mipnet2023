import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SaludoEditComponent } from './saludo-edit.component';

describe('SaludoEditComponent', () => {
  let component: SaludoEditComponent;
  let fixture: ComponentFixture<SaludoEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SaludoEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SaludoEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
