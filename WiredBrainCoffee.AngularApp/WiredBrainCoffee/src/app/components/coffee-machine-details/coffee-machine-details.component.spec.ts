import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CoffeeMachineDetailsComponent } from './coffee-machine-details.component';

describe('CoffeeMachineDetailsComponent', () => {
  let component: CoffeeMachineDetailsComponent;
  let fixture: ComponentFixture<CoffeeMachineDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CoffeeMachineDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CoffeeMachineDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
