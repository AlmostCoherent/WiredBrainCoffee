using System.Configuration;
using System.Windows;
using WiredBrainCoffee.EventHub.Sender;
using WiredBrainCoffee.MachineSimculator.UI.Service;
using WiredBrainCoffee.MachineSimculator.UI.ViewModel;

namespace WiredBrainCoffee.MachineSimculator.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var eventHubConnectionString =
                ConfigurationManager.AppSettings["EventHubConnectionString"];
            InitializeComponent();
            DataContext = new MainViewModel(new EventHubService());
        }
    }
}
