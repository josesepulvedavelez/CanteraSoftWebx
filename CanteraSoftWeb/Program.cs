using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CanteraSoftWeb.Services;

namespace CanteraSoftWeb
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddScoped<ClienteService>();

            var endPointBackEnd = builder.Configuration["EndPointBackEnd"];

            builder.Services.AddScoped(sp =>
            {
                return new HttpClient()
                {
                    BaseAddress = new Uri("https://localhost:5001")
                };
            });
            
            await builder.Build().RunAsync();
        }

    }
}
