using FleetInspection.Api.Extensions;
using FleetInspection.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbAccessStores(options => options.ConnectionString = connectionString);

builder.Services.AddEndpointDefinitions(new[]
{
    typeof(FleetInspection.Api.Models.MarkerModel),
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
builder.AllowAnyOrigin()
       .AllowAnyHeader()
       .AllowAnyMethod()
));

var app = builder.Build();

app.UseEndpointDefinitions();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
