using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Aula_TDD_Testes_Unitarios_integrados
{
    public class Calculadora : ICalculadora
    {
        public int Somar(int a, int b) => a + b;

    }



}
