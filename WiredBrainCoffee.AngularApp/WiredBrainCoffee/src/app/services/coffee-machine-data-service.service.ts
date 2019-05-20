import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { MachineData } from 'src/models/machineData';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root'
})

export class CoffeeMachineDataServiceService {

  public machineData: MachineData;
  private machineDataSource = new BehaviorSubject(this.machineData);
  machineDataMessage = this.machineDataSource.asObservable();

  constructor() {
  }

  changeMessage(machineData: MachineData) {
    this.machineDataSource.next(machineData);
    console.log(this.machineDataMessage);
  }

  getDefaultData() {
    if (!this.machineData) {
      this.machineData = new MachineData(Guid.create().toString().substring(0, 8), "London", 0, 0);
    }
    return this.machineData;
  }

  createMachineDataEspresso() {
    this.machineData.MakeEspresso();
  }

  createMachineDataCappuccino() {
    this.machineData.MakeCappuccino();
  }

}
