using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace Aula_Delegates_métodos_anônimos
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Nome).NotEmpty().WithName("Nome do Cliente ").WithMessage(" O Campo {PropertyName} Não foi informado");
            RuleFor(c => c.SobreNome).NotEmpty();
            //RuleFor(c => c.Nome).Length(10);
        }
    }
}