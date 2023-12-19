using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder()
							.AddJsonFile("ocelot.json")
							.Build();

builder.Services.AddCors(options =>
{
	options.AddPolicy("CORSPolicy",
		builder => builder
		.AllowAnyOrigin()
		.AllowAnyMethod()
		.AllowAnyHeader()
		.WithExposedHeaders("X-Pagination"));
});
builder.Services.AddOcelot(configuration);
var app = builder.Build();

app.UseCors("CORSPolicy");
app.UseHttpsRedirection();
await app.UseOcelot();
app.Run();
