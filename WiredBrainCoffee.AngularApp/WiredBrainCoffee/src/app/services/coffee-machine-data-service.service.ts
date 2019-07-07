import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { MachineData } from 'src/models/machineData';
import { Guid } from 'guid-typescript';
import { Console } from '@angular/core/src/console';

@Injectable({
  providedIn: 'root'
})

export class CoffeeMachineDataServiceService {

  public machineData: MachineData = new MachineData(Guid.create().toString().substring(0, 8), "London", 0, 0, 0, 0);;
  public machineDataSource = new BehaviorSubject(this.machineData);
  machineDataMessage = this.machineDataSource.asObservable();

  constructor() {
  }

  //changeMessage(machineData: MachineData) {
  //  this.machineDataSource.next(machineData);
  //  console.log(this.machineDataMessage);
  //}

  //sendData(): any {
  //  let subject = new Subject();
  //  subject.subscribe(value => console.log("Received new subscribe value: "))
  //  console.log(JSON.stringify(this.machineData));
  //}

  getData(): Observable<any> {
    const machineDataObservable = new Observable(observer => {
      setTimeout(() => {
        observer.next(this.machineData)
      }, 1000)
    });
    console.log("getDataResult: ", machineDataObservable);
    return machineDataObservable;
  }

  createMachineDataEspresso() {
    this.machineData.MakeEspresso();
  }

  createMachineDataCappuccino() {
    this.machineData.MakeCappuccino();
  }


}
