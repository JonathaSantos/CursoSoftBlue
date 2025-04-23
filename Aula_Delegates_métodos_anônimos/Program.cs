namespace Aula_Delegates_métodos_anônimos
{
    internal class Program
    {

        public delegate int MetodoDelegate(string nome);

        public static int QualquerMetodo(string pessoa) {
            Console.WriteLine("No método DELEGATE, Nome " + pessoa);
            return pessoa.Length;
        }

        public static void utilizaDelegate(MetodoDelegate metodoDelegate)
        {
           var letras = metodoDelegate(" Maria");
            Console.WriteLine($"Quantidade de LEtras: {letras}");
        }

        static void Main(string[] args)
        {

            utilizaDelegate(QualquerMetodo);

            // esse conceito ele é tipo
            //MetodoDelegate metodoDelegate = new MetodoDelegate(QualquerMetodo);
            MetodoDelegate metodoDelegate = QualquerMetodo;

            var letras = metodoDelegate(" Madalena");
            Console.WriteLine($"Quantidade de LEtras: {letras}");

            Console.ReadLine();
        }
    }
}
