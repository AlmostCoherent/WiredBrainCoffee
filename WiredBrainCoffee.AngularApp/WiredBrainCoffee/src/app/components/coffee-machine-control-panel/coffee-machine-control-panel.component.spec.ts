import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CoffeeMachineControlPanelComponent } from './coffee-machine-control-panel.component';

describe('CoffeeMachineControlPanelComponent', () => {
  let component: CoffeeMachineControlPanelComponent;
  let fixture: ComponentFixture<CoffeeMachineControlPanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CoffeeMachineControlPanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CoffeeMachineControlPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
