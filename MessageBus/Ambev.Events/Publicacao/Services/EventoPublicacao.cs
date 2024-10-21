using Microsoft.Extensions.Logging;
using System.Text.Json;


namespace Ambev.MessageBus.Publicacao.Services
{
    public class EventoPublicacao : IEventoPublicacao
    {
        private readonly ILogger<EventoPublicacao> _log;

        public EventoPublicacao(ILogger<EventoPublicacao> log)
        {
            _log = log;      
        }
        public void Publica(object evento)
        {
            var eventoJson = JsonSerializer.Serialize(evento);
            _log.LogInformation($"Evento publicado: {evento.GetType().Name} - {eventoJson}");
        }
    }
}
