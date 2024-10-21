using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.MessageBus.Publicacao.Services
{
    public interface IEventoPublicacao
    {
        void Publica(object evento);
    }
}
