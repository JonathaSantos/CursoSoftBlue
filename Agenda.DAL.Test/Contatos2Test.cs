using NUnit.Framework;
using System;
using System.ComponentModel;
using NUnit.Framework.Legacy;
using Agenda.Domain;
using System.Linq;
using AutoFixture;


namespace Agenda.DAL.Test
{
    [TestFixture]
    public class Contatos2Test : BaseTest
    {
        IContatos _contatos;
        Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _contatos = new IContatos();
            _fixture = new Fixture();
        }

        [Test]
        public void ObterTodosOsContatosTest()
        {
            // Monta
            var contato1 = _fixture.Create<Contato>();
            var contato2 = _fixture.Create<Contato>();


            // Executa
            _contatos.Adcionar(contato1);
            _contatos.Adcionar(contato2);
            var contatoListaResultado = _contatos.ObterTodosContato();
            var contatoResultado = contatoListaResultado.Where(o => o.Id == contato1.Id).FirstOrDefault();

            // Verifica
            ClassicAssert.AreEqual(2, contatoListaResultado.Count());
            ClassicAssert.AreEqual(contato1.Id, contatoResultado.Id);
            ClassicAssert.AreEqual(contato1.Nome, contatoResultado.Nome);

        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _fixture = null;
        }
    }
}