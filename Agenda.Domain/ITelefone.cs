using System;

namespace Agenda.Domain
{
    public interface ITelefone
    {
        Guid Id { get; set; }
        String Numero { get; set; }
        Guid ContatoId { get; set; }
    }
}
