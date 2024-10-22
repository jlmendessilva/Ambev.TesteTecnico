using Ambev.API.Services;
using Ambev.API.Services.Interfaces;
using Ambev.API.Services.Mappings;
using Ambev.Eventos.Broker;
using Ambev.Eventos.Publicacao;
using Ambev.IOC;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfra(builder.Configuration);
builder.Services.AddControllers();

var rabbitMQConfig = new RabbitMQConfig
{
    HostName = "moose.rmq.cloudamqp.com",
    UserName = "dyjzckeu",
    Password = "Gm1AhedFvjs3qYXoG6a14_DJFaR3RbrR",
    VirtualHost = "dyjzckeu",
    Port = 5671
};

builder.Services.AddSingleton(rabbitMQConfig);
builder.Services.AddSingleton<IRabbitMQConnectionFactory, RabbitMQConnectionFactory>();
builder.Services.AddSingleton<IEventoPublicacao, RabbitMQEventoPublicar>();

builder.Services.AddAutoMapper(typeof(MapEntitiesDto));
builder.Services.AddScoped<IVendaService, VendaService>();

builder.Services.AddLogging();


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
