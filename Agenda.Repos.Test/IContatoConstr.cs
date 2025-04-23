using Agenda.Domain;
using Agenda.DAL;
using AutoFixture;
using Moq;
using System;

namespace Agenda.Repos.Test
{
    public class IContatoConstr
    {
        private readonly Mock<IContato> _mockIContato;
        private readonly Fixture _fixture;

        protected IContatoConstr(Mock<IContato> mockIContato, Fixture fixture)
        {
            _mockIContato = mockIContato;
            _fixture = fixture;
        }

        public static IContatoConstr Um()
        {
            return new IContatoConstr(new Mock<IContato>(), new Fixture());
        }

        public IContato Construir()  {
            return _mockIContato.Object;
        }

        //public IContatoConstr Padrao()
        //{
        //    _mockIContato.SetupGet(o => o.Id).Returns(_fixture.Create<Guid>());
        //    _mockIContato.SetupGet(o => o.Numero).Returns(_fixture.Create<string>());
        //    _mockIContato.SetupGet(o => o.ContatoId).Returns(_fixture.Create<Guid>());
        //    return this;
        //}
        public IContatoConstr ComNome(string nome)
        {
            _mockIContato.SetupGet(o => o.Nome).Returns(nome);
            return this;
        }
        public IContatoConstr ComNumeroID(Guid id)
        {
            _mockIContato.SetupGet(o => o.Id).Returns(id);
            return this;
        }
        

    }
}