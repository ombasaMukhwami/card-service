using Cards.Services;
using Cards.Services.Contracts;
using Cards.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("V1", new OpenApiInfo { Title="Cards API", Version="v1" });
});


builder.Services.AddDbContext<CardDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("CardConnectionString")!,
    o => o.EnableRetryOnFailure())
        .EnableSensitiveDataLogging(false)
        .EnableDetailedErrors());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services
      .AddControllers()
      .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("swagger/v1/swagger.json", "CardsAPI v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
