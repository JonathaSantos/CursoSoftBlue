namespace Aula6
{
    public class ExecutarAcao<T>
    {
        private T _valor;

        public ExecutarAcao(T valor)
        {
            _valor = valor;
        }

        public void Valores(object ob)
        {
            if (ob.GetType().Name.Equals("Pessoa"))
            {
                var pessoa = new Pessoa();
                pessoa = (Pessoa)ob;
                string conta = pessoa.conta;
                int idade = pessoa.idade;
            }

        }
        public void TipoDados()
        {
            System.Console.WriteLine($"O tipo de dados {_valor.GetType()}");
        }
    }
}