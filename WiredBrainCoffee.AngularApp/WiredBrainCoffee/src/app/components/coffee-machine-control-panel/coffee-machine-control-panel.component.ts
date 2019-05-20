import { Component, OnInit } from '@angular/core';
import { CoffeeMachineDataServiceService } from 'src/app/services/coffee-machine-data-service.service';

@Component({
  selector: 'app-coffee-machine-control-panel',
  templateUrl: './coffee-machine-control-panel.component.html',
  styleUrls: ['./coffee-machine-control-panel.component.scss']
})
export class CoffeeMachineControlPanelComponent implements OnInit {

  constructor(private coffeeMachineDataService: CoffeeMachineDataServiceService) { }

  ngOnInit() {
  }

  makeEspresso() {
    this.coffeeMachineDataService.createMachineDataEspresso();
    console.log(this.coffeeMachineDataService.machineData.CounterEspresso);
  }

  makeCappuccino() {
    this.coffeeMachineDataService.createMachineDataCappuccino();
    console.log(this.coffeeMachineDataService.machineData.CounterCappuccino);
  }

}
