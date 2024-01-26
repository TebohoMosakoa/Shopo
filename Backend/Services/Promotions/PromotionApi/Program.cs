using Microsoft.EntityFrameworkCore;
using PromotionApi.Data;
using PromotionApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DB connection
builder.Services.AddDbContext<PromotionContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Default"), options => options.EnableRetryOnFailure()));

//Repositories
builder.Services.AddScoped<IPromotionRepository, PromotionRepository>();

var app = builder.Build();

//migrate the db
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<PromotionContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
