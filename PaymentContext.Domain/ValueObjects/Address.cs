using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public sealed class Address : ValueObject
{
    public Address(string neighborhood, string street, string number, string zipCode, string city, string state, string country)
    {
        Neighborhood = neighborhood;
        Street = street;
        Number = number;
        ZipCode = zipCode;
        City = city;
        State = state;
        Country = country;
    }

    public string Neighborhood { get; private set; }
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
}