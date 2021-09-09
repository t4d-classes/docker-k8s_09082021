using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Syncfusion.Licensing;
using Syncfusion.Blazor;

using TrainingContentCatalog.Common;
using TrainingContentCatalog.Web.Wasm.Services;

namespace TrainingContentCatalog.Web.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           SyncfusionLicenseProvider
              .RegisterLicense("NDkxMzc0QDMxMzkyZTMyMmUzME9Db1F3enhhUXZlTFdtNVl1R09sWHlyTE4xRzlJOHhNSk1FZ2dYN0E4K1U9");
            
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient {
              BaseAddress = builder.HostEnvironment.IsDevelopment()
                ? new("https://localhost:5051")
                : new(builder.HostEnvironment.BaseAddress)
            });

            builder.Services.AddSyncfusionBlazor();

            builder.Services.AddScoped<ITrainingContentSearch, TrainingContentSearchHttp>();
            builder.Services.AddScoped<IContentManager, ContentManagerHttp>();

            await builder.Build().RunAsync();
        }
    }
}
