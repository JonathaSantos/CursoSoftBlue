﻿using System;
using FluentValidation.Results;  

namespace Aula_Delegates_métodos_anônimos
{
    internal class Program
    {

        public delegate int MetodoDelegate(string nome);

        public delegate void MetodoDelegateLambda(int idade);
        public delegate int MetodoDelegateLambda2(string idade);


        //public delegate int MetodoDelegateGenerico(string idade);

        //Func<> Tem até 16 parametro de entrada e um parametro de retorno
        //Action<> Tem apenas parametros de entrada;
        // Predicate<> Tem um tipo de entrada e retona TRUE ou FALSO

        public static void utilizaDelegate(Func<string,int> metodoDelegate) // Delegate Generico até 17 parametros
        {
            var letras = metodoDelegate(" Maria");
            Console.WriteLine($"Quantidade de LEtras: {letras}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine(" Validando Cliente");
            // 
            Cliente cliente = new Cliente(); // {Nome = "Jonatha" };
            ClienteValidator clienteValidator = new ClienteValidator();
            ValidationResult validationResult = clienteValidator.Validate(cliente);
            //
            Console.WriteLine("REsultado da validação:  " + validationResult.IsValid + "\n\n");

            if (!validationResult.IsValid)
            {
                foreach (var erro in validationResult.Errors)
                {
                    Console.WriteLine($" Propriedade {erro.PropertyName} Msg: {erro.ErrorMessage} \n ");
                }
                
            }

            Console.WriteLine("\n\n");

            //  O tipo Nullable


            Nullable<bool> v1 = null;

            bool? v2 = null;
            bool v3 = false;


            if (v1 is null)
            {
                Console.WriteLine("Valor Nulo");
            }

            // forma de atribuir valores 
            if (v2.HasValue)
            {
                v3 = v2.Value;
            }

            if (v2 !=null)
            {
                v3 = v2.Value;
            }
            Console.WriteLine("Valor do v3 " + v3 + " \n\n");

            if (v2 is not null)
            {
                v3 = v2.Value;
            }
            Console.WriteLine("Valor do v3 " + v3 + " \n\n");

            v3 = v2.GetValueOrDefault();
            Console.WriteLine("Valor do v3 " + v3 + " \n\n");

            v3 = v2 ?? false;




            Console.WriteLine("Valor do v3 " + v3 + " \n\n") ;










            Predicate<int> pred = (num) => true; // delegate generico 
            Predicate<int> pred1 = (num) => num%2==0;

            Console.WriteLine("Resultado do Predicado: " + pred(1) + " - " + pred1(3));



            utilizaDelegate(delegate (string n)
            {
                Console.WriteLine(" Nome: " + n);
                return n.Length;
            });

            Func<string, int> metodoDelegateGenerico = (n) =>
            {
                Console.WriteLine(" Nome " + n);
                return n.Length; 
            };

            metodoDelegateGenerico(" Joantha ");

            MetodoDelegateLambda metodoLambda = (i) => { Console.WriteLine(" O bnúmero é " + i); };

            metodoLambda(23);


            MetodoDelegateLambda2 metodoLambda2 = (i) => { Console.WriteLine(" O bnúmero é " + i); return int.Parse(i); };

            metodoLambda2("37");

            // Delegates e expressões Lambda
            MetodoDelegate metodoDelegate =  (string n) =>
                {
                    Console.WriteLine(" Nome: " + n);
                    return n.Length;
                };



            var letras = metodoDelegate(" Madalena");
            Console.WriteLine($"Quantidade de LEtras: {letras}");

            Console.ReadLine();
        }
    }
}
