using Gyakorlas;
using Gyakorlas.Pages.Notification;
using Gyakorlas.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor.BroadcastChannel;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<StateService>();
//új cucc elvileg jóféle
builder.Services.AddBroadcastChannelAsSingleton();

builder.Services.AddSingleton<NotificationService>();

await builder.Build().RunAsync();


