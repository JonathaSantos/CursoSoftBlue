using Aula4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine($" E : {Matematica.e}"); // ou
            Console.WriteLine($"PI {Matematica.PI}");

            ContaBancaria c1 = new ContaBancaria();
            ContaBancaria c2 = new ContaBancaria();
            c1.numConta = 4567;
            c1.titular = "José";
            c1.Depositar(200);
            c1.Depositar(50);
            c1.Sacar(150);
            Console.WriteLine($"Saldo {c1.saldo} na conta {c1.numConta}");
            c1.Transferir(25, c2);


            int? rr = null; // ? nullble types
            if (rr == null)
            {
                Console.WriteLine("Valor é null");
            }
            if (!rr.HasValue)
            {
                Console.WriteLine("Valor é null usando outra forma");
            }
            /*
             * b2 recebe o valor de b1 
             * Se b1 for null, b2 recebe false
             */
            bool? b1 = null;
            bool b2 = b1 ?? false;

            Operacoes op = new Operacoes();
            int res;
            op.Somar(5, 5, out res);
            Console.WriteLine($"Args: {args[0]?.ToString()} - Somar {Somar(2, 6)}");
            Console.WriteLine($"Args: {args[1]?.ToString()} - Somar2 {res}");
            Console.WriteLine($"Args: {args[1]?.ToString()} - Somar {op.Somar(5, 5, 4, 2)}");
            Console.ReadLine();
        }


        static int Somar(int n1, int n2)
        {
            return n1 + n2;
        }

    }
    public class Matematica
    {
        public static readonly double e ; // definer sem o valor inicial e só depois de colocar o valor não tem como alterar.
        
        public const double PI = 3.1416;
        static Matematica()
        {
            e = 2.71828;

        }
    }
    public class Nubable
    {
        int? n = null;
        public void operacao()
        {
            //verificar se tá null
            if (n == null)
            {
                Console.WriteLine("Valor nulo");
            }
            if (!n.HasValue)
            {
                Console.WriteLine("Valor nulo");
            }

            // isso quer dizer que  n for igual null vai colocar 0
            // essa situação quando um variável é null e quando variável não suporta null esse é operador.
            int x = n ?? 0;
        }




    }
    public class Operacoes
    {
        public void Somar(int n1, int n2, out int r)
        {
            r = 0;
            r = n1 + n2;
        }
        public void Somar2(int n1, int n2, out int r, char op = '+')
        {
            r = 0;
            r = n1 + n2;
        }

        public int Somar(params int[] valores)
        {
            int soma = 0;
            foreach (var item in valores)
            {
                soma += item;
            }
            return soma;
        }
    }
}
