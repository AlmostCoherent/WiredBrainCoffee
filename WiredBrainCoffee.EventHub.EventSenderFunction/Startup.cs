using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WiredBrainCoffee.EventHub.EventSenderFunction.Services;
//using WiredBrainCoffee.EvenHub.EventSenderFunction.Services;

[assembly: FunctionsStartup(typeof(WiredBrainCoffee.EventHub.EventSenderFunction.Startup))]

namespace WiredBrainCoffee.EventHub.EventSenderFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();

            //builder.Services.AddScoped<IDataSenderService, DataSenderService>();
            //builder.Services.AddSingleton<IMyService>((s) =>
            //{
            //    return new MyService();
            //});

            builder.Services.AddSingleton<ICoffeeMachineDataService, CoffeeMachineDataService>();
        }
    }
}
