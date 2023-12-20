using Admin;
using Admin.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:8000/api/") });

builder.Services.AddScoped<BrandRepository>();
builder.Services.AddScoped<DepartmentRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<ProductRepository>();

await builder.Build().RunAsync();
