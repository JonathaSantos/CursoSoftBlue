using Aula_TDD_Testes_Unitarios_integrados;
using Moq;


namespace Projeto_Teste_Aula_TDD_
{
    public class CalculadoraTests
    {
        [Fact]
        public void Test1()
        {

        }

        /*
         Esse tipo de teste � �til quando:
             Voc� n�o quer testar a l�gica interna, mas sim o comportamento da integra��o.
            A l�gica j� foi testada e voc� quer simular a resposta.
            Est� testando classes que dependem da interface ICalculadora, e quer �fingir� que ela funciona corretamente.
         */
        [Theory]
        [InlineData(2, 3, 5)]
        public void Somar_DoisNumeros_RetornarSomaDosNumeros(int primeiroNumero, int segundoNumero, int ResultadoEsperado)
        {
            // Arrange
            var mockCalculadora = new Mock<ICalculadora>();
            mockCalculadora.Setup(o => o.Somar(primeiroNumero, segundoNumero)).Returns(ResultadoEsperado);

            //Act
            var resultado = mockCalculadora.Object.Somar(primeiroNumero, segundoNumero);

            //Assert
            Assert.Equal(ResultadoEsperado, resultado);

        }
        /*
         Aqui voc� est� testando a implementa��o real da classe Calculadora.
            A fun��o .Somar(...) realmente executa a l�gica e retorna o resultado.
            Esse � um teste de unidade real, onde voc� verifica se a l�gica da fun��o est� correta.
         */
        [Theory]
        [InlineData(2, 3, 5)]
        public void Somar_DoisNumeros2_RetornaSomaDosNumeros(int primeiroNumero, int segundoNumero, int resultadoEsperado)
        {
            //Arrange


            //Act
            var resultado = new Calculadora().Somar(primeiroNumero, segundoNumero);

            //Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}