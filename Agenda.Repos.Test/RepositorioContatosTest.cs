using Agenda.DAL;
using Agenda.Domain;
using AutoFixture;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agenda.Repos.Test
{

    [TestFixture]
    public class RepositorioContatosTest //: BaseTest
    {

        Mock<IContatosDAL> _contatos;
        Mock<ITelefones> _telefone;

        RepositorioContatos _repositorioContatos;

        Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Mock<IContatosDAL>();
            _telefone = new Mock<ITelefones>();

            _repositorioContatos = new RepositorioContatos(_contatos.Object, _telefone.Object);

            _fixture = new Fixture();
        }

        [Test]
        public void DeveSerPossivelObterContatoComListaTelefone()
        {
            Guid telefoneId = Guid.NewGuid();
            Guid contatoId = Guid.NewGuid();

            var lstTelefone = new List<ITelefone>();

            // Monta - arrange
            // Criar Moq de IContato
            var mContato = new Mock<IContato>();


            mContato.SetupGet(o => o.Id).Returns(contatoId);
            mContato.SetupGet(o => o.Nome).Returns("João");
            mContato.SetupSet(o => o.Telefones = It.IsAny<List<ITelefone>>())
                .Callback<List<ITelefone>>(p => lstTelefone = p);

            // Moq da função ObterPor ID de IContatos
            _contatos.Setup(o => o.Obter(contatoId)).Returns(mContato.Object);

            // Criar moq de Itelefone
            //var mTelefone = new Mock<ITelefone>();

            //mTelefone.SetupGet(o => o.Id).Returns(telefoneId);
            //mTelefone.SetupGet(j => j.Numero).Returns("1234-1234");
            //mTelefone.SetupGet(j => j.ContatoId).Returns(contatoId);

            // Agora com moq na classe
            var mockTelefone = ITelefoneConstr.Um().Padrao().ComId(telefoneId)
                .ComContatoId(contatoId).Construir();
            //
            _telefone.Setup(o => o.ObterTodosDoContato(contatoId))
                .Returns(new List<ITelefone> { mockTelefone });

            // Executa - act
            var contatoResultado = _repositorioContatos.ObterPorId(contatoId);
            
            mContato.SetupGet(o => o.Telefones).Returns(lstTelefone);

            // Verifica - Assert
            ClassicAssert.AreEqual(mContato.Object.Id, contatoResultado.Id);
            ClassicAssert.AreEqual(mContato.Object.Nome, contatoResultado.Nome);
            ClassicAssert.AreEqual(1, contatoResultado.Telefones.Count);
            ClassicAssert.AreEqual(mockTelefone.Numero, contatoResultado.Telefones[0].Numero);
            ClassicAssert.AreEqual(mockTelefone.Id, contatoResultado.Telefones[0].Id);
            ClassicAssert.AreEqual(mockTelefone.ContatoId, contatoResultado.Telefones[0].ContatoId);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _telefone = null;
            _fixture = null;
        }
    }
}