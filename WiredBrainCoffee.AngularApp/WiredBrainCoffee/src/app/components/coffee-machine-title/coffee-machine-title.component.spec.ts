import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CoffeeMachineTitleComponent } from './coffee-machine-title.component';

describe('CoffeeMachineTitleComponent', () => {
  let component: CoffeeMachineTitleComponent;
  let fixture: ComponentFixture<CoffeeMachineTitleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CoffeeMachineTitleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CoffeeMachineTitleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
