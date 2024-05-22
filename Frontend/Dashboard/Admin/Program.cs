using Admin;
using Admin.Helpers;
using Admin.Services;
using Admin.Services.Authentication;
using Admin.Services.Profile;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Tewr.Blazor.FileReader;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:8000/api/") });
builder.Services.AddFileReaderService(o => o.UseWasmSharedBuffer = true);

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddScoped<BrandRepository>();
builder.Services.AddScoped<DepartmentRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
await builder.Build().RunAsync();
