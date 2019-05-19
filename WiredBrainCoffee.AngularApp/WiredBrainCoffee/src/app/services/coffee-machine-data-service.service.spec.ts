import { TestBed } from '@angular/core/testing';

import { CoffeeMachineDataServiceService } from './coffee-machine-data-service.service';

describe('CoffeeMachineDataServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CoffeeMachineDataServiceService = TestBed.get(CoffeeMachineDataServiceService);
    expect(service).toBeTruthy();
  });
});
