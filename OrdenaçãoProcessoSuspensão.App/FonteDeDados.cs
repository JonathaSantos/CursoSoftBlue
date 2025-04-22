using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenaçãoProcessoSuspensão.App
{
    internal class FonteDeDados
    {
        public static IList<ProcessoSuspensaoDto> GeListaProcessoSuspensao()
        {
            var protocolo = "999";
            var lista = new List<ProcessoSuspensaoDto>();
           
            lista.Add(new ProcessoSuspensaoDto()
            {
                ID = 3,
                Modelo = "NOTIF-PSDD-MAIS-AUTOS",
                Protocolo = protocolo,
                ProcessoDefesaRecurso = "",
                AutorizacaoConjunta = ""
            });
     
            lista.Add(new ProcessoSuspensaoDto()
            {
                ID = 5,
                Modelo = "GERCAP11-NOVO",
                Protocolo = protocolo,
                ProcessoDefesaRecurso = "",
                AutorizacaoConjunta = "444"
            });
            lista.Add(new ProcessoSuspensaoDto()
            {
                ID = 6,
                Modelo = "GERCAP08-NOVO",
                Protocolo = protocolo,
                ProcessoDefesaRecurso = "99999",
                AutorizacaoConjunta = ""
            });
            lista.Add(new ProcessoSuspensaoDto()
            {
                ID = 7,
                Modelo = "GERCAP02-NOVO",
                Protocolo = protocolo,
                ProcessoDefesaRecurso = "",
                AutorizacaoConjunta = ""
            });
            lista.Add(new ProcessoSuspensaoDto()
            {
                ID = 8,
                Modelo = "GERCAP02-NOVO-1AUTO",
                Protocolo = protocolo,
                ProcessoDefesaRecurso = "",
                AutorizacaoConjunta = ""
            });
            lista.Add(new ProcessoSuspensaoDto()
            {
                ID = 9,
                Modelo = "GERCAP04-NOVO",
                Protocolo = protocolo,
                ProcessoDefesaRecurso = "",
                AutorizacaoConjunta = ""
            });
            lista.Add(new ProcessoSuspensaoDto()
            {
                ID = 10,
                Modelo = "GERCAP21-NOVO",
                Protocolo = protocolo,
                ProcessoDefesaRecurso = "",
                AutorizacaoConjunta = ""
            });
            lista.Add(new ProcessoSuspensaoDto()
            {
                ID = 11,
                Modelo = "GERCAP09-NOVO",
                Protocolo = protocolo,
                ProcessoDefesaRecurso = "",
                AutorizacaoConjunta = ""
            });
            lista.Add(new ProcessoSuspensaoDto()
            {
                ID = 12,
                Modelo = "GERCAP20-NOVO",
                Protocolo = protocolo,
                ProcessoDefesaRecurso = "",
                AutorizacaoConjunta = ""
            });
            lista.Add(new ProcessoSuspensaoDto()
            {
                ID = 13,
                Modelo = "GERCAP19-NOVO",
                Protocolo = protocolo,
                ProcessoDefesaRecurso = "",
                AutorizacaoConjunta = ""
            });
            lista.Add(new ProcessoSuspensaoDto()
            {
                ID = 14,
                Modelo = "GERCAP07-NOVO",
                Protocolo = protocolo,
                ProcessoDefesaRecurso = "44458",
                AutorizacaoConjunta = ""
            });
            lista.Add(new ProcessoSuspensaoDto()
            {
                ID = 4,
                Modelo = "GERCAP01-NOVO",
                Protocolo = protocolo,
                ProcessoDefesaRecurso = "",
                AutorizacaoConjunta = ""
            });
            lista.Add(new ProcessoSuspensaoDto()
            {
                ID = 1,
                Modelo = "CAPA-PSDD",
                Protocolo = protocolo,
                ProcessoDefesaRecurso = protocolo,
                AutorizacaoConjunta = ""
            });
            lista.Add(new ProcessoSuspensaoDto()
            {
                ID = 2,
                Modelo = "NOTIF-PSDD-1AUTO",
                Protocolo = protocolo,
                ProcessoDefesaRecurso = "",
                AutorizacaoConjunta = ""
            });
            return lista;
        }

    }
}
