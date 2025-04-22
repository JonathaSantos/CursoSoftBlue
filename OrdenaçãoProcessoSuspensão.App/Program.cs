
using System.Collections.Immutable;

namespace OrdenaçãoProcessoSuspensão.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("# Colocar na Ordem o processo #");

            ColocarOrdemPSDD();
            // InserirNaLista();
            Console.ReadKey();
        }

        private static void InserirNaLista()
        {
            List<Pessoa> pessoas;
            pessoas = new List<Pessoa>();
            pessoas.Add(new Pessoa(50, "Macoratti"));
            pessoas.Add(new Pessoa(25, "Jefferson"));
            pessoas.Add(new Pessoa(45, "Miriam"));
            ImprimirPessoa(pessoas);

            pessoas.Insert(1, new Pessoa() { Nome = "Bob Dylan", Idade = 78 });

            ImprimirPessoa(pessoas);

        }

        private static void ImprimirPessoa(List<Pessoa> pessoas)
        {
            foreach (Pessoa p in pessoas)
            {
                Console.WriteLine(p.Nome + " " + p.Idade);
            }
            Console.WriteLine(Environment.NewLine);
        }

        private static void ColocarOrdemPSDD()
        {
            var processoDto = FonteDeDados.GeListaProcessoSuspensao();
            Imprimir(processoDto);

            foreach (var item in processoDto)
            {
                switch (item.Modelo)
                {
                    case "CAPA-PSDD":
                        item.ModeloOrdem = 0;
                        break;
                    case "NOTIF-PSDD-1AUTO":
                        item.ModeloOrdem = 1;
                        break;
                    case "NOTIF-PSDD-MAIS-AUTOS":
                        item.ModeloOrdem = 1;
                        break;
                    case "GERCAP01-NOVO":
                        item.ModeloOrdem = 2;
                        break;
                    case "GERCAP11-NOVO":
                        item.ModeloOrdem = 3;
                        break;
                    case "GERCAP08-NOVO":
                        item.ModeloOrdem = 4;
                        break;
                    case "GERCAP02-NOVO":
                        item.ModeloOrdem = 5;
                        break;
                    case "GERCAP02-NOVO-1AUTO":
                        item.ModeloOrdem = 6;
                        break;
                    case "GERCAP04-NOVO":
                        item.ModeloOrdem = 7;
                        break;
                    case "GERCAP21-NOVO":
                        item.ModeloOrdem = 8;
                        break;
                    case "GERCAP09-NOVO":
                        item.ModeloOrdem = 9;
                        break;
                    case "GERCAP20-NOVO":
                        item.ModeloOrdem = 10;
                        break;
                    case "GERCAP19-NOVO":
                        item.ModeloOrdem = 11;
                        break;
                    case "GERCAP07-NOVO":
                        item.ModeloOrdem = 12;
                        break;
                    default:
                        item.ModeloOrdem = -1;
                        break;
                }
            }
            Imprimir(processoDto);

            var listaNova = processoDto.ToList();
            listaNova.Sort(new ProcessoComparecer());

            //var listaNova = FazerNovaLista(processoDto);

            //listaNova.OrderBy(x => x.ModeloOrdem);

            Imprimir(listaNova);

            for (int i = 0; i < listaNova.Count; i++)
            {
                if (listaNova[i].Modelo.Equals("GERCAP08-NOVO") && !string.IsNullOrEmpty(listaNova[i].ProcessoDefesaRecurso))
                {
                    listaNova.Insert(i + 1, new ProcessoSuspensaoDto() { Modelo = "Jonatha Insert", ID = i });
                }
            }
            //var i = 0;
            //foreach (var item in listaNova) 
            //{ 

            //    if (item.Modelo.Equals("GERCAP08-NOVO") && !string.IsNullOrEmpty(item.ProcessoDefesaRecurso)) 
            //    {
            //        listaNova.Insert(i+1,new ProcessoSuspensaoDto() {Modelo= "Jonatha Insert", ID = i });
            //    }
            //    i++;
            //}
            Imprimir(listaNova);
        }

        private static IList<ProcessoSuspensaoDto> FazerNovaLista(IList<ProcessoSuspensaoDto> processoDto)
        {
            if (processoDto == null)
            {
                return null;
            }

            var aindaTemTroca = true;

            do
            {
                if (processoDto.Count <= 0)
                {
                    return null;
                }

                if (processoDto.Count > 0)
                {
                    for (int x = 0; x < processoDto.Count - 1; x++)
                    {
                        for (int y = 1; y < processoDto.Count; y++)
                        {

                        }
                    }
                }

            } while (aindaTemTroca);

            return processoDto;
        }

        private static void Imprimir(IList<ProcessoSuspensaoDto> processoDto)
        {
            Console.WriteLine("#---------------------------------#");
            Console.WriteLine($"{string.Join($" |{Environment.NewLine} ", processoDto.ToList())}");
            Console.WriteLine(Environment.NewLine);
        }
    }
}
