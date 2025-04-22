using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenaçãoProcessoSuspensão.App
{
    internal enum Modelo
    {
        [Description("CAPA-PSDD")]
        CAPA_PSDD = 0,

        [Description("NOTIF-PSDD-1AUTO")]
        NOTIF_PSDD_1AUTO = 1,

        [Description("NOTIF-PSDD-MAIS_AUTOS")]
        NOTIF_PSDD_MAIS_AUTOS = 1,

        [Description("GERCAP01-NOVO")]
        GERCAP01_NOVO = 2,

        [Description("GERCAP11-NOVO")]
        GERCAP11_NOVO = 3,

        [Description("GERCAP08-NOVO")]
        GERCAP08_NOVO = 4,

        [Description("GERCAP02-NOVO")]
        GERCAP02_NOVO = 5,

        [Description("GERCAP02-NOVO-1AUTO")]
        GERCAP02_NOVO_1AUTO = 6,

        [Description("GERCAP04-NOVO")]
        GERCAP04_NOVO = 7,

        [Description("GERCAP21-NOVO")]
        GERCAP21_NOVO = 8,

        [Description("GERCAP09-NOVO")]

        GERCAP09_NOVO = 9,
        [Description("GERCAP20-NOVO")]
        GERCAP20_NOVO = 10,

        [Description("GERCAP19-NOVO")]
        GERCAP19_NOVO = 11,

        [Description("GERCAP07-NOVO")]
        GERCAP07_NOVO = 12,
    }
}

