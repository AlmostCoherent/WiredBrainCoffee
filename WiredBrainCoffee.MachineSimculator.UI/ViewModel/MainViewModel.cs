using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using WiredBrainCoffee.EventHub.Sender;
using WiredBrainCoffee.EventHub.Sender.Model;

namespace WiredBrainCoffee.MachineSimculator.UI.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private int _counterCappuccino;
        private int _counterEspresso;
        private string _city;
        private string _serialNumber;
        private ICoffeeMachineDataSender _coffeeMachineDataSender;

        public MainViewModel(ICoffeeMachineDataSender coffeeMachineDataSender)
        {
            _coffeeMachineDataSender = coffeeMachineDataSender;
            SerialNumber = System.Guid.NewGuid().ToString().Substring(0,8);
            MakeCappuccinoCommand = new DelegateCommand(MakeCappuccino);
            MakeEspressoCommand = new DelegateCommand(MakeEspresso);
        }
        public ICommand MakeCappuccinoCommand { get; }
        public ICommand MakeEspressoCommand { get; }
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                RaisePropertyChanged();
            }
        }
        public string SerialNumber
        {
            get { return _serialNumber; }
            set
            {
                _serialNumber = value;
                RaisePropertyChanged();
            }
        }
        public int CounterCappuccino
        {
            get { return _counterCappuccino; }
            set
            {
                _counterCappuccino = value;
                RaisePropertyChanged();
            }
        }
        public int CounterEspresso
        {
            get { return _counterEspresso; }
            set
            {
                _counterEspresso = value;
                RaisePropertyChanged();
            }
        }
        private async void MakeCappuccino()
        {
            CounterCappuccino++;
            CoffeeMachineData coffeeMachineData = CreateCoffeeMachineData(
                nameof(CounterCappuccino), CounterCappuccino);
            await SendDataAsync(coffeeMachineData);
        }
        private async void MakeEspresso()
        {
            CounterEspresso++;
            CoffeeMachineData coffeeMachineData = CreateCoffeeMachineData(
                nameof(CounterEspresso), CounterEspresso);
            await SendDataAsync(coffeeMachineData);
        }

        private CoffeeMachineData CreateCoffeeMachineData(string sensorType, int sensorValue)
        {
            return new CoffeeMachineData()
            {
                City = City,
                SerialNumber = SerialNumber,
                SensorType = sensorType,
                SensorValue = sensorValue,
                RecordingTime = DateTime.Now
            };
        }

        private async Task SendDataAsync(CoffeeMachineData coffeeMachineData)
        {
            await _coffeeMachineDataSender.SendDataAsync(coffeeMachineData);
        }
    }
}
