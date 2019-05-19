import { Component, OnInit } from '@angular/core';
import { CoffeeMachineDataServiceService } from '../../services/coffee-machine-data-service.service';

@Component({
  selector: 'app-coffee-machine-title',
  templateUrl: './coffee-machine-title.component.html',
  styleUrls: ['./coffee-machine-title.component.css']
})
export class CoffeeMachineTitleComponent implements OnInit {

  constructor(private coffeeMachineDataService: CoffeeMachineDataServiceService) { }

  ngOnInit() {
  }
}
