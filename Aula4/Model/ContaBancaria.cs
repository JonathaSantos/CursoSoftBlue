namespace Aula4.Model
{
    internal class ContaBancaria
    {
        public string titular { get; set; }
        public int numConta { get; set; }
        public double saldo { get; set; }

        public void Sacar(double valor)
        {
            saldo -= valor;
        }
        public void Depositar(double valor)
        { 
            saldo += valor;
        }
        public void Transferir(double valor, ContaBancaria contaDestino)
        {
            Sacar(valor);
            contaDestino.Depositar(valor);
        }
    }
}
