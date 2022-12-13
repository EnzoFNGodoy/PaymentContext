using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Tests.Data;

public class CommandsData
{
    public CreateBoletoSubscriptionCommand BoletoSubscriptionCommand = new()
    {
        StudentFirstName = "Enzo",
        StudentLastName = "Godoy",
        StudentDocument = "17248021832",
        StudentEmail = "enzo.godoy@godoy.io",
        BarCode = "3897126098376",
        BoletoNumber = "0001",
        PaymentNumber = "43892",
        PaymentDate = DateTime.Now.AddDays(2),
        ExpirationDate = DateTime.Now.AddMonths(1),
        Total = (decimal)99.99,
        TotalPaid = (decimal)109.99,
        Payer = "Enzo Godoy",
        PayerEmail = "enzo.godoy@godoy.io",
        PayerDocument = "17248021832",
        PayerDocumentType = EDocumentType.CPF,
        PayerNeighborhood = "Vista Verde",
        PayerStreet = "Avenida Pedro Friggi",
        PayerNumber = "2600",
        PayerZipCode = "12223430",
        PayerCity = "São José dos Campos",
        PayerState = EState.SP,
        PayerCountry = "Brasil"
    };

    public CreatePayPalSubscriptionCommand PayPalSubscriptionCommand = new()
    {
        StudentFirstName = "Enzo",
        StudentLastName = "Godoy",
        StudentDocument = "17248021832",
        StudentEmail = "enzo.godoy@godoy.io",
        TransactionCode = "T34728",
        PaymentNumber = "4523423",
        PaymentDate = DateTime.Now.AddMinutes(1),
        ExpirationDate = DateTime.Now.AddMonths(6),
        Total = (decimal)124.99,
        TotalPaid = (decimal)124.99,
        Payer = "Enzo Godoy",
        PayerEmail = "enzo.godoy@godoy.io",
        PayerDocument = "17248021832",
        PayerDocumentType = EDocumentType.CPF,
        PayerNeighborhood = "Vista Verde",
        PayerStreet = "Avenida Pedro Friggi",
        PayerNumber = "2600",
        PayerZipCode = "12223430",
        PayerCity = "São José dos Campos",
        PayerState = EState.SP,
        PayerCountry = "Brasil"
    };

    public CreateCreditCardSubscriptionCommand CreditCardSubscriptionCommand = new()
    {
        StudentFirstName = "Enzo",
        StudentLastName = "Godoy",
        StudentDocument = "47263029812",
        StudentEmail = "enzo.godoy@godoy.io",
        CardHolderName = "Enzo Godoy",
        CardNumber = "1234567890123456",
        LastTransactionNumber = "3456",
        PaymentNumber = "4523423",
        PaymentDate = DateTime.Now.AddDays(5),
        ExpirationDate = DateTime.Now.AddMonths(6),
        Total = (decimal)124.99,
        TotalPaid = (decimal)124.99,
        Payer = "Enzo Godoy",
        PayerEmail = "enzo.godoy@godoy.io",
        PayerDocument = "17248021832",
        PayerDocumentType = EDocumentType.CPF,
        PayerNeighborhood = "Vista Verde",
        PayerStreet = "Avenida Pedro Friggi",
        PayerNumber = "2600",
        PayerZipCode = "12223430",
        PayerCity = "São José dos Campos",
        PayerState = EState.SP,
        PayerCountry = "Brasil"
    };
}