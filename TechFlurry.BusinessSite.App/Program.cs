using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TechFlurry.BusinessSite.App;
using TechFlurry.BusinessSite.App.Interops;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#wrapper");
builder.RootComponents.Add<HeadOutlet>("head::after");

var hostEnv = builder.HostEnvironment;

if (!hostEnv.IsDevelopment())
{
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://techflurryapi.azurewebsites.net/") });
}
else
{
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7176/") });
}
builder.Services.AddScoped<IFirebaseInterop, FirebaseInterop>();

await builder.Build().RunAsync();
