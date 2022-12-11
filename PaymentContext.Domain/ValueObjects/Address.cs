using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Helpers;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public sealed class Address : ValueObject
{
    public Address(string neighborhood, string street, string number, string zipCode, string city,
        EState state, string country)
    {
        Neighborhood = neighborhood;
        Street = street;
        Number = number;
        ZipCode = zipCode;
        City = city;
        State = state;
        Country = country;

        AddNotifications(new Contract<Address>()
            .Requires()
            .IsLowerThan(Neighborhood, 3, "Address.Neighborhood", "O bairro deve conter pelo menos 3 caracteres.")
            .IsGreaterThan(Neighborhood, 100, "Address.Neighborhood", "O bairro não deve conter mais de 100 caracteres.")
            .IsLowerThan(Street, 3, "Address.Street", "A rua deve conter pelo menos 3 caracteres.")
            .IsGreaterThan(Street, 100, "Address.Street", "A rua não deve conter mais de 100 caracteres.")
            .IsLowerThan(Number, 1, "Address.Number", "O número deve conter pelo menos 1 caracteres.")
            .IsGreaterThan(Number, 10, "Address.Number", "O número não deve conter mais de 10 caracteres.")
            .IsTrue(ZipCodeIsValid(), "Address.ZipCode", "Código postal inválido")
            .IsLowerThan(City, 3, "Address.City", "A cidade deve conter pelo menos 3 caracteres.")
            .IsGreaterThan(City, 150, "Address.City", "A cidade não deve conter mais de 150 caracteres.")
            .IsTrue(EnumValidator<EState>.IsValid((int)State), "Address.State", "Estado inválido")
            .IsLowerThan(City, 3, "Address.Country", "O país deve conter pelo menos 3 caracteres.")
            .IsGreaterThan(City, 150, "Address.Country", "O país não deve conter mais de 150 caracteres.")
        );
    }

    public string Neighborhood { get; private set; }
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }
    public EState State { get; private set; }
    public string Country { get; private set; }

    private bool ZipCodeIsValid()
    {
        if (ZipCode.Length == 8)
            return true;

        return false;
    }
}