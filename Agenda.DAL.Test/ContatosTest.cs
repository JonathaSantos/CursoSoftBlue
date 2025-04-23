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
        IContatos _contatos;
        Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _contatos = new IContatos();
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

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _fixture = null;
        }
    }
}
