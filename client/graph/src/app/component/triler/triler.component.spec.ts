import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrilerComponent } from './triler.component';

describe('TrilerComponent', () => {
  let component: TrilerComponent;
  let fixture: ComponentFixture<TrilerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TrilerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TrilerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
