using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public sealed class PayPalPayment : Payment
{
    public PayPalPayment(
        string transactionCode,
        DateTime paymentDate, 
        DateTime? expirationDate,
        decimal total,
        decimal totalPaid, 
        string payer,
        Document document,
        Address address,
        Email email) : base(
            paymentDate,
            expirationDate, 
            total, 
            totalPaid, 
            payer, 
            document, 
            address, 
            email)
    {
        TransactionCode = transactionCode;
    }

    public string TransactionCode { get; private set; }
}
