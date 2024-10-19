using System.Text.Json.Serialization;

namespace Ambev.Domain.Entities
{
    public abstract class Entity
    {
        [JsonPropertyName("id")]
        public Guid Id { get; protected set; }

    }
}
