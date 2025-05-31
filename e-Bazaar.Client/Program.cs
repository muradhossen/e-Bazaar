using e_Bazaar.Client;
using e_Bazaar.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7230") });
builder.Services.AddBlazorBootstrap();



#region DI

builder.Services.AddScoped<IProductService, ProductService>();

#endregion

await builder.Build().RunAsync();
