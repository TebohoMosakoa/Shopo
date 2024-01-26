using Admin;
using Admin.Services;
using Admin.Services.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Tewr.Blazor.FileReader;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:8000/api/") });
builder.Services.AddFileReaderService(o => o.UseWasmSharedBuffer = true);

builder.Services.AddScoped<BrandRepository>();
builder.Services.AddScoped<DepartmentRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

await builder.Build().RunAsync();
