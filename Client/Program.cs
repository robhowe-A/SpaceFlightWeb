using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpaceFlightWeb.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient("APIClient", client =>
{
    //client.BaseAddress = new Uri("https://localhost:7266/");
    //client.BaseAddress = new Uri("https://spaceflight.local:443");
    client.BaseAddress = new Uri("https://www.spaceflight.dev");


});

await builder.Build().RunAsync();
