using Ambev.ConsumerQueue.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Ambev.ConsumerQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var consumer = host.Services.GetRequiredService<RabbitMQConsumer>();
            var filas = new List<string> { "compraCriada", "compraAlterada", "compraCancelada", "ItemCancelado" };
            consumer.Consume(filas);
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var rabbitMQConfig = new RabbitMQConfig
                    {
                        HostName = "moose.rmq.cloudamqp.com",
                        UserName = "dyjzckeu",
                        Password = "Gm1AhedFvjs3qYXoG6a14_DJFaR3RbrR",
                        VirtualHost = "dyjzckeu",
                        Port = 5671
                    };

                    services.AddSingleton(rabbitMQConfig);
                    services.AddSingleton<IRabbitMQConnectionFactory, RabbitMQConnectionFactory>();
                    services.AddSingleton<RabbitMQConsumer>();
                });
    }
}
