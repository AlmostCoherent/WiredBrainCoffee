import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { MachineData, CoffeeType } from 'src/models/machineData';
import { Guid } from 'guid-typescript';
import { Console } from '@angular/core/src/console';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MachineEvent } from 'src/models/coffeeDataEvent';

@Injectable({
  providedIn: 'root'
})

export class CoffeeMachineDataServiceService {
  update(machineData: MachineData) {
    this.machineData = machineData;
    this.machineDataSource.next(this.machineData);

  }

  public machineData: MachineData = new MachineData(Guid.create().toString().substring(0, 8), "London", 0, 0, 0, 0);;
  public machineDataSource = new BehaviorSubject<MachineData>(this.machineData);
  machineDataMessage = this.machineDataSource.asObservable();
  dummyPostUrl : string = "https://localhost:44347/event/send";

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  
  constructor(private http: HttpClient) {
  }

  sendData(postThis: any): Observable<any> {
    let postData = JSON.stringify(postThis);
    return this.http.post<any>(this.dummyPostUrl, postData, this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.errorHandl)
    )
  }

  createMachineDataEspresso() {
    this.machineData.MakeEspresso();
    this.machineData.CoffeeType = CoffeeType.Espresso;
    let event = this.getEventObject("CounterEspresso");
    this.sendData(event).subscribe();
  }

  createMachineDataCappuccino() {
    this.machineData.MakeCappuccino();
    this.machineData.CoffeeType = CoffeeType.Cappuccino;
    let event = this.getEventObject("CounterCappuccino");
    this.sendData(event).subscribe();
  }
  
  private getEventObject(type: string){
    let event = new MachineEvent(this.machineData.SerialNumber,
      this.machineData.Location, 
      type,
      this.machineData.CounterEspresso,
      new Date())
      return [event];
  }
  // Error handling
  errorHandl(error) {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }


}
