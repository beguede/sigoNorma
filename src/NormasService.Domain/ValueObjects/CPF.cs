using Flunt.Validations;
using NormasService.Domain.Core.ValueObjects;

namespace NormasService.Domain.ValueObjects
{
    public class CPF : ValueObject
    {
        public CPF(string numero)
        {
            Numero = numero;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(Numero, nameof(CPF.Numero), "CPF não pode ser nulo ou branco")
                .HasLen(Numero, 11, nameof(CPF.Numero), "CPF deve conter 11 posições")
                .IsDigit(Numero, nameof(CPF.Numero), "CPF deve conter apenas números"));
        }

        public string Numero { get; private set; }

        public override string ToString()
        {
            return Numero;
        }
    }
}