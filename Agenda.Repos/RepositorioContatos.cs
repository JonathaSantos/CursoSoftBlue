using Agenda.DAL;
using Agenda.Domain;
using System;
using System.Collections.Generic;

namespace Agenda.Repos
{
    public class RepositorioContatos
    {
        private readonly IContatosDAL _contatos;

        private readonly ITelefones _telefones;

        public RepositorioContatos(IContatosDAL contatos, ITelefones telefones)
        {
            _contatos = contatos;
            _telefones = telefones;
        }

        public IContato ObterPorId(Guid id)
        {
            IContato contato = _contatos.Obter(id);
            List<ITelefone> lstTelefone = _telefones.ObterTodosDoContato(id);

            contato.Telefones = lstTelefone;

            return contato;
        }

    }
}
