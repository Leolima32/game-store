import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddgenreComponent } from './addgenre.component';

describe('AddgenreComponent', () => {
  let component: AddgenreComponent;
  let fixture: ComponentFixture<AddgenreComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddgenreComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddgenreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
