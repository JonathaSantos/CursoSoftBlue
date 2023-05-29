namespace Aula7.Heranca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            
            var moto = new Moto();

            var a = new Gato();
            a.EmitirSom(a);
            a.MostrarPatas();

            Console.ReadKey();
        }
    }
}