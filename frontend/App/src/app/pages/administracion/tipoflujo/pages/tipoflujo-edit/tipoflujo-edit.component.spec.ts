import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoflujoEditComponent } from './tipoflujo-edit.component';

describe('TipoflujoEditComponent', () => {
  let component: TipoflujoEditComponent;
  let fixture: ComponentFixture<TipoflujoEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TipoflujoEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TipoflujoEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
