using System;
using System.Collections.Generic;

namespace Agenda.Domain
{
    public interface IContato
    {
        Guid Id { get; set; }
        String Nome { get; set; }
        List<ITelefone> Telefones { get; set; }
    }
}
