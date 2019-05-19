export class MachineData {
  public SerialNumber: string;
  public City: string;
  public CounterCappuccino: number;
  public CounterEspresso: number;
    
  constructor(
    serialNumber: string,
    city: string,
    counterCappuccino: number,
    counterEspresso: number
  ) {
    this.SerialNumber = serialNumber;
    this.City = city;
    this.CounterCappuccino = counterCappuccino;
    this.CounterEspresso = counterEspresso;
  }

  public MakeCappuccino() {
    this.CounterCappuccino++;
  }

  public MakeEspresso() {
    this.CounterEspresso++;
  }

}
