using Agenda.Domain;
using AutoFixture;
using Moq;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Repos.Test
{
    public class BaseConstr<T> where T : class
    {
        protected readonly Fixture _fixture;
        protected readonly Mock<T> _mock;
        protected BaseConstr()
        {
            _fixture = new Fixture();
            _mock = new Mock<T>();
        }

        public T Construir()
        {
            return _mock.Object;
        }

        public Mock<T> Obter()
        {
            return _mock;
        }
    }

    public class ITelefoneConstr : BaseConstr<ITelefone>
    {
        //protected readonly Mock<ITelefone> _mockTelefone;
        //protected readonly Fixture _fixture;

        //protected ITelefoneConstr(Mock<ITelefone> mockTelefone)
        //{
        //    _mockTelefone = mockTelefone;

        //}
        protected ITelefoneConstr() : base()
        {

        }
        public static ITelefoneConstr Um()
        {
            //return new ITelefoneConstr(new Mock<ITelefone>());
            return new ITelefoneConstr();
        }

        //public ITelefone Construir()
        //{
        //    return _mockTelefone.Object;
        //}

        public ITelefoneConstr Padrao()
        {
            _mock.SetupGet(o => o.Id).Returns(_fixture.Create<Guid>());
            _mock.SetupGet(o => o.Numero).Returns(_fixture.Create<string>());
            _mock.SetupGet(o => o.ContatoId).Returns(_fixture.Create<Guid>());
            return this;
        }
        public ITelefoneConstr ComId(Guid id)
        {
            _mock.SetupGet(o => o.Id).Returns(id);
            return this;
        }
        public ITelefoneConstr ComNumero(string numero)
        {
            _mock.SetupGet(o => o.Numero).Returns(numero);
            return this;
        }
        public ITelefoneConstr ComContatoId(Guid contatoID)
        {
            _mock.SetupGet(o => o.ContatoId).Returns(contatoID);
            return this;
        }

    }
}