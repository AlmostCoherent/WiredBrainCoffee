import { Component, OnInit, Input } from '@angular/core';
import { CoffeeMachineDataServiceService } from 'src/app/services/coffee-machine-data-service.service';
import { MachineData } from 'src/models/machineData';

@Component({
  selector: 'app-coffee-machine-details',
  templateUrl: './coffee-machine-details.component.html',
  styleUrls: ['./coffee-machine-details.component.scss']
})
export class CoffeeMachineDetailsComponent implements OnInit {

  machineData: MachineData;

  constructor(private coffeeMachineDataService: CoffeeMachineDataServiceService) { }

  ngOnInit() {
    this.coffeeMachineDataService.machineDataSource.subscribe(
      success => {
        console.log(success);
        this.machineData = success;
      },
      error => {
        console.log(error);
      }
      );
  }

  updateLocationValue(value: any) {
    this.machineData.Location = value;
    this.coffeeMachineDataService.update(this.machineData);
    console.log(value);
  }

  updateSerialValue(value: any) {
    this.machineData.SerialNumber = value;
    this.coffeeMachineDataService.update(this.machineData);
    console.log(value);
  }
}
