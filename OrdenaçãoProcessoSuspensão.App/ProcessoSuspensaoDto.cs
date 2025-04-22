using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenaçãoProcessoSuspensão.App
{
    internal class ProcessoSuspensaoDto
    {
        public long ID { get; set; } = 0;
        public string Modelo { get; set; } = string.Empty;
        public string Protocolo { get; set; } = string.Empty;
        public string AutorizacaoConjunta { get; set; } = string.Empty;
        public string ProcessoDefesaRecurso { get; set; } = string.Empty;

        public int ModeloOrdem { get; set; } = 0; 


    public override string ToString()
        {
            
            return $"ID: {ID}, Modelo: {Modelo}, ModeloOrdem: {ModeloOrdem} , Protocolo: {Protocolo}, AutorizacaoConjunta: {AutorizacaoConjunta}, ProcessoDefesaRecurso: {ProcessoDefesaRecurso} ";
        }
    }
}
