using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public sealed class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(new Contract<Name>()
            .Requires()
            .IsLowerThan(FirstName, 45, "Name.FirstName", "O primeiro nome não deve conter mais de 45 caracteres")
            .IsGreaterThan(FirstName, 3, "Name.FirstName", "O primeiro nome deve conter pelo menos 3 caracteres")
            .IsLowerThan(LastName, 45, "Name.LastName", "O último nome não deve conter mais de 45 caracteres")
            .IsGreaterThan(LastName, 3, "Name.LastName", "O último nome deve conter pelo menos 3 caracteres")
        );
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public override string ToString() => $"{FirstName} {LastName}";
}