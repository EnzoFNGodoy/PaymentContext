using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

public sealed class StudentTests
{
    private readonly Student _student;
    private readonly Subscription _subscription;
    private readonly Name _name;
    private readonly Document _document;
    private readonly Address _address;
    private readonly Email _email;
    private readonly Payment _payment;

    public StudentTests()
    {
        _name = new Name("Cristiano", "Ronaldo");
        _document = new Document("51347666060", EDocumentType.CPF);
        _email = new Email("cristiano.ronaldo@CR7.com");
        _address = new Address("Bairro Gajo", "Rua Manchester Utd", "007", "00770000", "Ilha da Madeira",
            EState.SP, "BR");

        _student = new Student(_name, _document, _email, _address);

        _subscription = new Subscription(null);
        _payment = new PayPalPayment("12345", DateTime.Now.AddHours(1), DateTime.Now.AddDays(10), 10, 10,
           "CR7", _document, _address, _email);
    }

    [Fact]
    public void ShouldReturn_Error_When_Had_ActiveSubscription()
    {
        _subscription.AddPayment(_payment);

        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);

        Assert.False(_student.IsValid);
    }

    [Fact]
    public void ShouldReturn_Error_When_Had_Subscription_Has_NoPayment()
    {
        _student.AddSubscription(_subscription);

        Assert.False(_student.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_When_AddSubscription()
    {
        _subscription.AddPayment(_payment);

        _student.AddSubscription(_subscription);

        Assert.True(_student.IsValid);
    }
}