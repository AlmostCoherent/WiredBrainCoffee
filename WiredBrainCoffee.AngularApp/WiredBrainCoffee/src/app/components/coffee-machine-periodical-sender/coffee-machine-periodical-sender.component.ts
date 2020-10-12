import { Component, OnInit, OnDestroy } from '@angular/core';
import { CoffeeMachineDataServiceService } from 'src/app/services/coffee-machine-data-service.service';
import { MachineData } from 'src/models/machineData';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-coffee-machine-periodical-sender',
  templateUrl: './coffee-machine-periodical-sender.component.html',
  styleUrls: ['./coffee-machine-periodical-sender.component.scss']
})
export class CoffeeMachinePeriodicalSenderComponent implements OnInit {

  constructor(private coffeeMachineDataService: CoffeeMachineDataServiceService) { }

//  model: MachineData = new MachineData(Guid.create().toString().substring(0, 8), "London", 0, 0, 0, 0);
  data: MachineData;
  statusText: string;


  ngOnInit() {
    //const machineDataObservable = this.coffeeMachineDataService.getData();
    //machineDataObservable.subscribe(
    //  (machineData: any) => {
    //    this.data = machineData;
    //  },
    //  err => {
    //    console.log(err)
    //  }
    //)

    //console.log(this.data);
    this.coffeeMachineDataService.machineDataSource.subscribe(
      success => {
        console.log(success);
        this.data = success;
      },
      error => {
        console.log(error);
      }
      );

  }

  sendPeriodically() {
  }

}
