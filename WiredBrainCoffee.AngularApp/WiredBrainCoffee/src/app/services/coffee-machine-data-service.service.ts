import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { MachineData } from 'src/models/machineData';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root'
})

export class CoffeeMachineDataServiceService {

  private machineData: MachineData;
  private machineDataSource = new BehaviorSubject(this.machineData);
  machineDataMessage = this.machineDataSource.asObservable();

  constructor() {
  }

  changeMessage(machineData: MachineData) {
    this.machineDataSource.next(machineData);
    console.log(this.machineDataMessage);
  }

  getDefaultData() {
    return new MachineData(Guid.create().toString().substring(0, 8), "London", 0, 0);
  }
}
