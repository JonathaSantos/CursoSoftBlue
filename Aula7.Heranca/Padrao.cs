using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula7.Heranca
{
    public class Padrao
    {
        public Padrao(int p)
        {

        }
    }
    public class Automovel : Padrao
    {
        public string modelo { get; set; }
        public Automovel() : base(20) // construtor
        {

        }
    }

    interface ICarro
    {
        void Modelo();
    }
    interface IMotorizado
    {
        void Ligar();
        void Desligar();
    }

    public class Moto : Padrao, IMotorizado, ICarro  // classe primeiro depois Interfaces.
    {
        public Moto() : base(20)
        {

        }
        public void Ligar() { }
        public void Desligar() { }
        public void Modelo() { }

    }
    interface IExamploA { }
    interface IExamploB { }
    interface IExamploC : IExamploA, IExamploB // implementação multiplua 
    { }

    public abstract class Animal
    {
        public abstract void MostrarPatas(); 

        public int quantidadePatas { get; set; }
        public void Falar() { }
        public void EmitirSom(Animal a)
        {
            a.Falar();
        }
    }
    public class Gato : Animal
    {
        public override void MostrarPatas()
        {
            throw new NotImplementedException();
        }
    }



}
