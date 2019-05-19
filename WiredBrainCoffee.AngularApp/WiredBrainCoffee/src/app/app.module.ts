import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CoffeeMachineTitleComponent } from './components/coffee-machine-title/coffee-machine-title.component';
import { CoffeeMachineDetailsComponent } from './components/coffee-machine-details/coffee-machine-details.component';
import { CoffeeMachineControlPanelComponent } from './components/coffee-machine-control-panel/coffee-machine-control-panel.component';

@NgModule({
  declarations: [
    AppComponent,
    CoffeeMachineTitleComponent,
    CoffeeMachineDetailsComponent,
    CoffeeMachineControlPanelComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
