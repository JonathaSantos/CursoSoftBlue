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
    public class ContatosTest : BaseTest
    {
        Contatos _contatos;
        Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();
            _fixture = new Fixture();
        }

        [Test]
        public void Test()
        {
            // Monta - arrange

            // Executa - act

            // Verifica - Assert
        }

        [Test]
        public void IncluirContatoTest()
        {
            // Monta
            var contato = _fixture.Create<Contato>();
            //var contato = new Contato()
            //{
            //    Id = _fixture.Create<Guid>(), //Guid.NewGuid(),
            //    Nome = _fixture.Create<string>()//$"Jonatha_teste_{DateTime.Now.ToString("dd/MM/yyyy | HH:mm:ss.ff")}"
            //};
            

            // Executa
            _contatos.Adcionar(contato);

            // Verifica
            ClassicAssert.True(true);

        }

        [Test]
        [DisplayName("teste Obter Contato no banco SQL")]
        public void ObterContatoTest()
        {
            // Monta
            var contato = _fixture.Create<Contato>();
            


            // Executa
            _contatos.Adcionar(contato);
            var contatoResultado = _contatos.ObterContato(contato.Id);

            // Verifica
            ClassicAssert.AreEqual(contato.Id, contatoResultado.Id);
            ClassicAssert.AreEqual(contato.Nome, contatoResultado.Nome);

        }

        [Test]
        public void ObterTodosOsContatosTest()
        {
            // Monta
            var contato1 = _fixture.Create<Contato>();
            var contato2 = _fixture.Create<Contato>();
            //var contato1 = new Contato()
            //{
            //    Id = Guid.NewGuid(),
            //    Nome = $"Jonatha_teste_{DateTime.Now.ToString("dd/MM/yyyy | HH:mm:ss.ff")}"
            //};

            //var contato2 = new Contato()
            //{
            //    Id = Guid.NewGuid(),
            //    Nome = $"Rafaela_teste_{DateTime.Now.ToString("dd/MM/yyyy | HH:mm:ss.ff")}"
            //};


            // Executa
            _contatos.Adcionar(contato1);
            _contatos.Adcionar(contato2);
            var contatoListaResultado = _contatos.ObterTodosContato();
            var contatoResultado = contatoListaResultado.Where(o => o.Id == contato1.Id).FirstOrDefault();

            // Verifica
            ClassicAssert.IsTrue(contatoListaResultado.Count() > 1);
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
