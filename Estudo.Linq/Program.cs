namespace Estudo.Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
           // Exemplo1();
            Exemplo2();
        }

        public static void Exemplo1()
        {
            IList<string> frutas = new List<string>() { "Banana", "Maça", "Pera", "Laranja", "Uva" };

            // query syntax
            var resultado = from f in frutas
                            where f.Contains('r')
                            select f;

            Console.WriteLine($"resultado foi: {string.Join(" - ", resultado)}");

            var resultado2 = frutas.Where(x => x.Contains('r'));


            Console.WriteLine($"resultado2 foi: {string.Join(" - ", resultado2)}");

            Console.WriteLine($"Frutas foi: {frutas.ElementAt(1)}");
            Console.WriteLine($"Frutas foi: {frutas.FirstOrDefault()}");
            Console.WriteLine($"Frutas foi: {string.Join(" - ", frutas.Order().ToList())}");
            Console.WriteLine($"Frutas foi: {(frutas.Min())}");
            Console.WriteLine($"Frutas foi: {(frutas.Max())}");
            Console.ReadKey();
            Console.Clear();

        }

        public static void Exemplo2()
        {
            IList<string> nomes = new List<string>() { "Maria", "Miriam", "Carlos", "Manoel" };

            string? resultado = nomes.First(nome => nome.Equals("Carlos"));

            Console.WriteLine($"");
            Console.WriteLine($"O nome é {resultado}");
            Console.WriteLine("#------------");
            Console.WriteLine(Environment.NewLine);
            var t = nomes.Where(j => j.Contains("M"));
            Console.WriteLine("Resultado da Variaevel T " + t.FirstOrDefault());



            Console.ReadKey();

        }
    }
}
