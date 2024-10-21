using Ambev.API.Services;
using Ambev.API.Services.Interfaces;
using Ambev.API.Services.Mappings;
using Ambev.IOC;
using Ambev.EventoMenssage.MessageBroker.RabbitMq;
using Ambev.EventoMenssage.Publicacao.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfra(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MapEntitiesDto));
builder.Services.AddScoped<IVendaService, VendaService>();

var rabbitMQConfig = new RabbitMQConfig
{
    HostName = "amqps://dyjzckeu:Gm1AhedFvjs3qYXoG6a14_DJFaR3RbrR@moose.rmq.cloudamqp.com/dyjzckeu",
    UserName = "dyjzckeu:dyjzckeu",
    Password = "Gm1AhedFvjs3qYXoG6a14_DJFaR3RbrR"
};
var connection = RabbitMQConnectionFactory.GetConnection(rabbitMQConfig);

builder.Services.AddSingleton<IEventoPublicacao, RabbitMQEventoPublicar>();
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
