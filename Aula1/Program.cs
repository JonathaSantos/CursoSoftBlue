using System;
using System.Collections.Generic;
using System.Linq;

namespace Aula1
{
    class Program
    {
        static void Main(string[] args)
        {
            var listA = new List<Lista>();


            var listB = new List<Lista>();

            listA.Add(new Lista { Id = 1 });
            listA.Add(new Lista { Id = 1 });
            listA.Add(new Lista { Id = 2 });
            listA.Add(new Lista { Id = 2 });
            listA.Add(new Lista { Id = 1 });
            listA.Add(new Lista { Id = 5 });


            listB.Add(new Lista { Id = 1 });
            listB.Add(new Lista { Id = 1 });
            listB.Add(new Lista { Id = 2 });
            listB.Add(new Lista { Id = 3 });
            listB.Add(new Lista { Id = 4 });

            var repetidos = listA
                             .GroupBy(x => x.Id)
                             .Where(g => g.Count() > 1)
                             .Select(g => g.Key)
                             .ToList();

            foreach (var item in repetidos)
            {
                listA.RemoveAll(x => x.Id == item);
                listB.RemoveAll(x => x.Id == item);
            }

            System.Console.WriteLine("Teste");




            ///
            Console.ReadKey();
        }

        public ArquivosPDF IndicesPaginas(List<Byte> listaEntrada)
        {
            var arquivosPDF = new ArquivosPDF();
            try
            {
                foreach (var item in listaEntrada)
                {
                    int totalPagina = 1; // colocar chamada para pegar total de página
                    switch (totalPagina)
                    {
                        case 1:
                            arquivosPDF.arquivoPDfTotalPagina1.Add("");
                            break;
                        default:
                            break;
                    }

                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
    public class ArquivosPDF
    {
        public List<string> arquivoPDfTotalPagina1 { get; set; } = null;
        public List<string> arquivoPDfTotalPagina2 { get; set; } = null;
    }
    public class Lista
    {
        public int Id { get; set; }
    }

}
