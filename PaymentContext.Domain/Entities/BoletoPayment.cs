using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public sealed class BoletoPayment : Payment
{
    public BoletoPayment(
        string barCode, 
        string boletoNumber, 
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
        BarCode = barCode;
        BoletoNumber = boletoNumber;
    }

    public string BarCode { get; private set; }
    public string BoletoNumber { get; private set; }
}