namespace Aula_Delegates_métodos_anônimos
{
    internal class Program
    {

        public delegate int MetodoDelegate(string nome);

        public delegate void MetodoDelegateLambda(int idade);
        public delegate int MetodoDelegateLambda2(string idade);
        public static void utilizaDelegate(MetodoDelegate metodoDelegate)
        {
            var letras = metodoDelegate(" Maria");
            Console.WriteLine($"Quantidade de LEtras: {letras}");
        }

        static void Main(string[] args)
        {

            utilizaDelegate(delegate (string n)
            {
                Console.WriteLine(" Nome: " + n);
                return n.Length;
            });

            MetodoDelegateLambda metodoLambda = (i) => { Console.WriteLine(" O bnúmero é " + i); };

            metodoLambda(23);


            MetodoDelegateLambda2 metodoLambda2 = (i) => { Console.WriteLine(" O bnúmero é " + i); return int.Parse(i); };

            metodoLambda2("37");

            // Delegates e expressões Lambda
            MetodoDelegate metodoDelegate =  (string n) =>
                {
                    Console.WriteLine(" Nome: " + n);
                    return n.Length;
                };



            var letras = metodoDelegate(" Madalena");
            Console.WriteLine($"Quantidade de LEtras: {letras}");

            Console.ReadLine();
        }
    }
}
