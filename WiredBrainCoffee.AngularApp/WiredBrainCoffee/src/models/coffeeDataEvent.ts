export class MachineEvent {
  public SerialNumber: string;
  public City: string;
  public SensorType: string;
  public SensorValue: number;
  public RecordingTime: Date;    
  
  constructor(
    SerialNumber: string,
    City: string,
    SensorType: string,
    SensorValue: number,
    RecordingTime: Date
  ) {
    this.SerialNumber = SerialNumber;
    this.City = City;
    this.SensorType = SensorType;
    this.SensorValue = SensorValue;
    this.RecordingTime = RecordingTime;
  }
}