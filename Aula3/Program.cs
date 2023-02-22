using System;

namespace Aula3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BlocoVariaveis();
            BlocoRepeticao();
            System.Console.ReadKey();
        }

        private static void BlocoVariaveis()
        {
            const int numero =10;
            double nota = 9.5;
            decimal dinheiro = 0;
            Console.WriteLine($"numero { numero} nota {nota} dinheiro {dinheiro}");
            
        }

        private static void BlocoRepeticao()
        {
            int x = 1;
            while (x < 6)
            {
                System.Console.WriteLine($"Mensagem while {x}");
                x++;
                break;// força a saída de um loop
            }

            do
            {
              
                System.Console.WriteLine($"Mensagem do while {x}");
                x++;

            } while (x < 15);

            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    continue;
                }
                System.Console.WriteLine($"Mensagem for {i}");
            }
            int[] array = { 5, 2, 3, 1, 7 };
            foreach (var item in array)
            {
                System.Console.WriteLine($"Mensagem foreach {item}");
            }
        }
    }
}