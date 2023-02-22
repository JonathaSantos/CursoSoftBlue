using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aula6
{
    public class Program
    {
        static void Main(string[] args)
        {
            ExecutarAcao<int> iAcao = new ExecutarAcao<int>(21);
            iAcao.TipoDados();
            Pessoa pessoa = new Pessoa();
            ExecutarAcao<Pessoa> iAcao2 = new ExecutarAcao<Pessoa>(pessoa);
            iAcao2.Valores(pessoa);
            iAcao2.TipoDados();
            //ExecutaAcao<decimal> dAcao = new ExecutaAcao<decimal>(21.55m);
            //dAcao.IdentificaTipoDado();
            //ExecutaAcao<string> sAcao = new ExecutaAcao<string>("Macoratti .net");
            //sAcao.IdentificaTipoDado();
            //DataSet dsData = new DataSet();
            //ExecutaAcao<DataSet> oAction = new ExecutaAcao<DataSet>(dsData);
            //oAction.IdentificaTipoDado();
            Console.ReadLine();
        }
    }
}