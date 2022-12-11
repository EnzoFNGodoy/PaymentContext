

using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public sealed class CreditCardPayment : Payment
{
    public CreditCardPayment(
        string cardHolderName, 
        string cardNumber, 
        string lastTransactionNumber,
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
        CardHolderName = cardHolderName;
        CardNumber = cardNumber;
        LastTransactionNumber = lastTransactionNumber;
    }

    public string CardHolderName { get; private set; }
    public string CardNumber { get; private set; }
    public string LastTransactionNumber { get; private set; }
}