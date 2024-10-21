
namespace Ambev.EventoMenssage.Eventos
{
    public class CompraAlterada
    {
        public Guid CompraId { get; set; }
        public DateTime DataAlteracao { get; set; }
        public Guid ClienteId { get; set; }
    }
}
