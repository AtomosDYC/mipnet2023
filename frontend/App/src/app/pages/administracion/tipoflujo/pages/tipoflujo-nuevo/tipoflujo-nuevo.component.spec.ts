import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoflujoNuevoComponent } from './tipoflujo-nuevo.component';

describe('TipoflujoNuevoComponent', () => {
  let component: TipoflujoNuevoComponent;
  let fixture: ComponentFixture<TipoflujoNuevoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TipoflujoNuevoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TipoflujoNuevoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
