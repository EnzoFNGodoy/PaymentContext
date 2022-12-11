using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public sealed class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        ValidateFirstName();
        ValidateLastName();
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    private void ValidateFirstName()
    {
        if (string.IsNullOrEmpty(FirstName) ||
            string.IsNullOrWhiteSpace(FirstName))
            AddNotification("Name.FirstName", "Nome inválido");

        if (FirstName.Length < 3 || FirstName.Length > 45)
            AddNotification("Name.FirstName", "O primeiro nome não pode ter menos de 3 caracteres ou mais de 45 caracteres");
    }

    private void ValidateLastName()
    {
        if (string.IsNullOrEmpty(LastName) ||
            string.IsNullOrWhiteSpace(LastName))
            AddNotification("Name.LastName", "Nome inválido");

        if (LastName.Length < 3 || LastName.Length > 60)
            AddNotification("Name.LastName", "O último nome não pode ter menos de 3 caracteres ou mais de 60 caracteres");
    }
}