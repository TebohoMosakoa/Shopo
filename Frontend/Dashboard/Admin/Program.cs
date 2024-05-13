using Admin;
using Admin.Services;
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
builder.Services.AddScoped<PromotionRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPromotionProductRepository, PromotionProductRepository>();

await builder.Build().RunAsync();
