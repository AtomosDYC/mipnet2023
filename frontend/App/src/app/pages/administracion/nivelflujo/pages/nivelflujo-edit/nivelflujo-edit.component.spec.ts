import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NivelflujoEditComponent } from './nivelflujo-edit.component';

describe('NivelflujoEditComponent', () => {
  let component: NivelflujoEditComponent;
  let fixture: ComponentFixture<NivelflujoEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NivelflujoEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NivelflujoEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
