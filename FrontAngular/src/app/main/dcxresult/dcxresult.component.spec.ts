import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DCXResultComponent } from './dcxresult.component';

describe('DCXResultComponent', () => {
  let component: DCXResultComponent;
  let fixture: ComponentFixture<DCXResultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DCXResultComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DCXResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
