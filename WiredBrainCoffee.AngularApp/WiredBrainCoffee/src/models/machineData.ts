export class MachineData {
  public SerialNumber: string;
  public Location: string;
  public BeanLevel: number;
  public BoilerTemp: number;
  public CounterCappuccino: number;
  public CounterEspresso: number;
  public CoffeeType: CoffeeType;    
  
  constructor(
    serialNumber: string,
    location: string,
    counterCappuccino: number,
    counterEspresso: number,
    boilerTemp: number,
    beanLevel: number
  ) {
    this.SerialNumber = serialNumber;
    this.Location = location;
    this.CounterCappuccino = counterCappuccino;
    this.CounterEspresso = counterEspresso;
    this.BeanLevel = beanLevel;
    this.BoilerTemp = boilerTemp;
  }

  public MakeCappuccino() {
    this.CounterCappuccino++;
  }

  public MakeEspresso() {
    this.CounterEspresso++;
  }

}

export enum CoffeeType {
  Cappuccino = 1,
  Espresso
}