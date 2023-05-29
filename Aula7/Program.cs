using System;
using System.ComponentModel;

namespace Aula7
{
    class Teste
    {
        public static T ObterAtributoDoTipo<T>(Enum valorEnum) where T : System.Attribute
        {
            var type = valorEnum.GetType();
            var memInfo = type.GetMember(valorEnum.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
        public static string ObterDescricao(Enum valorEnum)
        {
            //return valorEnum.ObterAtributoDoTipo<DescriptionAttribute>().Description;
            return ObterAtributoDoTipo<Enum>(valorEnum);
        }
        public enum MeuEnumerador
        {
            [Description("Descrição do item do enumerador")]
            Enumerador1 = 1,
            [Description("Outra descrição")]
            Enumerador2 = 2
        }
    }
    class Program
    {
    
        static void Main(string[] args)
        {
            Teste.ObterDescricao(Teste.MeuEnumerador.Enumerador1);
        }
      


       
    }
}
