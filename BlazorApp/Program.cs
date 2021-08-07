using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //StaticGenerator.InitModels(10, 10);
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");



            builder.Services.AddHttpClient<ITrackService, TrackService>(
                client => client.BaseAddress = new Uri("https://localhost:44364/"));

            builder.Services.AddHttpClient<ITraineeService, TraineeService>(
                client => client.BaseAddress = new Uri("https://localhost:44364/"));

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
