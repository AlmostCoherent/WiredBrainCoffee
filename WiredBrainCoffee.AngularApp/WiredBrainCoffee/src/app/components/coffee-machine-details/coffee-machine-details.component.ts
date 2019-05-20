import { Component, OnInit } from '@angular/core';
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
    this.machineData = this.coffeeMachineDataService.getDefaultData();
    console.log(this.machineData);
  }
}
