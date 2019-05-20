import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CoffeeMachinePeriodicalSenderComponent } from './coffee-machine-periodical-sender.component';

describe('CoffeeMachinePeriodicalSenderComponent', () => {
  let component: CoffeeMachinePeriodicalSenderComponent;
  let fixture: ComponentFixture<CoffeeMachinePeriodicalSenderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CoffeeMachinePeriodicalSenderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CoffeeMachinePeriodicalSenderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
