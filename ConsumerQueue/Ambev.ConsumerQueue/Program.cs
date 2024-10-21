
using Ambev.ConsumerQueue;

Console.WriteLine("Leitura das filas");
Console.WriteLine("====================");

var connectionString = "hostname=localhost;username=guest;password=guest";
var consumer = new RabbitMQConsumer(connectionString);

consumer.Consume("compraCriadaFila");
consumer.Consume("compraAlteradaFila");
consumer.Consume("compraCanceladaFila");
consumer.Consume("itemCanceladoFila");



