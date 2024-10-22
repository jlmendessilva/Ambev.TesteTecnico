using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Eventos.Publicacao
{
    public interface IEventoPublicacao
    {
        void Publica<T>(string queueName, T evento);
    }
}
