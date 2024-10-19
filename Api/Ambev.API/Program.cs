using Ambev.API.Services;
using Ambev.API.Services.Interfaces;
using Ambev.API.Services.Mappings;
using Ambev.Data.Interfaces;
using Ambev.Data.Repositories;
using Ambev.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfra(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MapEntitiesDto));
builder.Services.AddScoped<IVendaService, VendaService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
