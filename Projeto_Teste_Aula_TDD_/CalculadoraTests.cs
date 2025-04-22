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
         Esse tipo de teste é útil quando:
             Você não quer testar a lógica interna, mas sim o comportamento da integração.
            A lógica já foi testada e você quer simular a resposta.
            Está testando classes que dependem da interface ICalculadora, e quer “fingir” que ela funciona corretamente.
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
         Aqui você está testando a implementação real da classe Calculadora.
            A função .Somar(...) realmente executa a lógica e retorna o resultado.
            Esse é um teste de unidade real, onde você verifica se a lógica da função está correta.
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