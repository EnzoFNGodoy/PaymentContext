using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public abstract class Payment
{
    protected Payment(DateTime paymentDate, DateTime? expirationDate, decimal total,
        decimal totalPaid, string payer, Document document, Address address, Email email)
    {
        Number = Guid.NewGuid().ToString().Replace("-", "")[..10].ToUpper();
        PaymentDate = paymentDate;
        ExpirationDate = expirationDate;
        Total = total;
        TotalPaid = totalPaid;
        Payer = payer;
        Document = document;
        Address = address;
        Email = email;
    }

    public string Number { get; private set; }
    public DateTime PaymentDate { get; private set; }
    public DateTime? ExpirationDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public string Payer { get; private set; }
    public Document Document { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }
}
