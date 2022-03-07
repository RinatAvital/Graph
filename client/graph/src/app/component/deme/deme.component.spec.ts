import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DemeComponent } from './deme.component';

describe('DemeComponent', () => {
  let component: DemeComponent;
  let fixture: ComponentFixture<DemeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DemeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DemeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
