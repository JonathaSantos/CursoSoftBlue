namespace FFMPEGAppTeste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            TesteFFMPEG testeFFMPEG = new TesteFFMPEG();
            testeFFMPEG.TesteVideo();
            Console.ReadKey();
        }
    }
}