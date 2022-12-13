using PaymentContext.Shared.ValueObjects;
using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects;

public sealed class Email : ValueObject
{
    public Email(string address)
    {
        Address = address;

        AddNotifications(new Contract<Email>()
            .Requires()
            .IsEmail(Address, "Email.Address", "E-mail inválido")
        );
    }

    public string Address { get; private set; }

    public override string ToString() => $"{Address}";
}