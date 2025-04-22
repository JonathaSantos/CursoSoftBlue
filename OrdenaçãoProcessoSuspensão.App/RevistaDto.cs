using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenaçãoProcessoSuspensão.App
{
    internal class RevistaDto
    {
        public IList<long> ListaID { get; set; }
        public IList<string> Modelo { get; set; }
        public IList<string> ListaProtocolo { get; set; }
        public IList<string> AutorizacaoConjunta { get; set; }
        public IList<string> ProcessoDefesaRecurso { get; set; }
        
        public RevistaDto()
        {
            ListaID = new List<long>();
            Modelo = new List<string>();
            ListaProtocolo = new List<string>();
            AutorizacaoConjunta = new List<string>();
            ProcessoDefesaRecurso = new List<string>();
        }

    }
}
