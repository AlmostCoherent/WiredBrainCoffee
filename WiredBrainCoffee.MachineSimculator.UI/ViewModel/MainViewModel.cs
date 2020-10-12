using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using WiredBrainCoffee.EventHub.Sender;
using WiredBrainCoffee.EventHub.Sender.Model;
using WiredBrainCoffee.MachineSimculator.UI.Service;

namespace WiredBrainCoffee.MachineSimculator.UI.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private int _counterCappuccino;
        private int _counterEspresso;
		private int _beanLevel;
		private int _boilerTemp;
        private string _city;
        private string _serialNumber;
        private IEventHubService _eventHubService;
		private bool _isSendingPeriodically;
		private DispatcherTimer _dispatcherTimer;

        public MainViewModel(IEventHubService eventHubService)
        {
            _eventHubService = eventHubService;
            SerialNumber = System.Guid.NewGuid().ToString().Substring(0,8);
            MakeCappuccinoCommand = new DelegateCommand(MakeCappuccino);
            MakeEspressoCommand = new DelegateCommand(MakeEspresso);
			Logs = new ObservableCollection<string>();

			_dispatcherTimer = new DispatcherTimer
			{
				Interval = TimeSpan.FromSeconds(2)
			};
			_dispatcherTimer.Tick += DispatchTimer_Tick;
		}

		private async void DispatchTimer_Tick(object sender, EventArgs e)
		{
			var boilerTempData = CreateCoffeeMachineData(nameof(BoilerTemp), BoilerTemp);
			var beanLevelData = CreateCoffeeMachineData(nameof(BeanLevel), BeanLevel);

			await SendDataAsync(new[] { boilerTempData, beanLevelData });
		}

		public ICommand MakeCappuccinoCommand { get; }
        public ICommand MakeEspressoCommand { get; }
		public ObservableCollection<string> Logs { get;  }
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
		public int BeanLevel
		{
			get { return _beanLevel; }
			set
			{
				_beanLevel = value;
				RaisePropertyChanged();
			}
		}
		public int BoilerTemp
		{
			get { return _boilerTemp; }
			set
			{
				_boilerTemp = value;
				RaisePropertyChanged();
			}
		}
		public bool IsSendingPeriodically
		{
			get { return _isSendingPeriodically; }
			set
			{
				_isSendingPeriodically = value;
				if (_isSendingPeriodically)
				{
					_dispatcherTimer.Start();
				}
				else
				{
					_dispatcherTimer.Stop();
				}
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
			try
			{
				List<CoffeeMachineData> coffeeMachineDatas = new List<CoffeeMachineData>();
				coffeeMachineDatas.Add(coffeeMachineData);
				await _eventHubService.SendEventData(coffeeMachineDatas);
				WriteLog($"Sent data: { coffeeMachineData }");
			}
			catch (Exception ex)
			{
				WriteLog($"Exception: {ex.Message}");
			}
        }
		private async Task SendDataAsync(IEnumerable<CoffeeMachineData> coffeeMachineData)
		{
			try
			{
				await _eventHubService.SendEventData(coffeeMachineData);
				foreach (var data in coffeeMachineData)
				{
					WriteLog($"Sent data: { data }");
				}
			}
			catch (Exception ex)
			{
				WriteLog($"Exception: {ex.Message}");
			}
		}
		private void WriteLog(string logMessage)
		{
			Logs.Insert(0, logMessage);
		}
    }
}
