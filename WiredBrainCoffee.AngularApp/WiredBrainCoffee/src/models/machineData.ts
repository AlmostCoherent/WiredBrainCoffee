export class MachineData {
  public SerialNumber: string;
  public City: string;
  public BeanLevel: number;
  public BoilerTemp: number;
  public CounterCappuccino: number;
  public CounterEspresso: number;
    
  constructor(
    serialNumber: string,
    city: string,
    counterCappuccino: number,
    counterEspresso: number,
    boilerTemp: number,
    beanLevel: number
  ) {
    this.SerialNumber = serialNumber;
    this.City = city;
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
