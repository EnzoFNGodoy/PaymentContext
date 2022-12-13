﻿using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public sealed class CreatePayPalSubscriptionCommand : Notifiable<Notification>, ICommand
{
    public string StudentFirstName { get; set; }
    public string StudentLastName { get; set; }
    public string StudentDocument { get; set; }
    public string StudentEmail { get; set; }

    public string TransactionCode { get; set; }

    public string PaymentNumber { get; set; }
    public DateTime PaymentDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }

    public string Payer { get; set; }
    public string PayerEmail { get; set; }
    public string PayerDocument { get; set; }
    public EDocumentType PayerDocumentType { get; set; }

    public string PayerNeighborhood { get; set; }
    public string PayerStreet { get; set; }
    public string PayerNumber { get; set; }
    public string PayerZipCode { get; set; }
    public string PayerCity { get; set; }
    public EState PayerState { get; set; }
    public string PayerCountry { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<CreatePayPalSubscriptionCommand>()
            .Requires()
            .IsLowerThan(StudentFirstName, 45, "CreatePayPalSubscriptionCommand.StudentFirstName", "O primeiro nome não deve conter mais de 45 caracteres")
            .IsGreaterThan(StudentFirstName, 3, "CreatePayPalSubscriptionCommand.StudentFirstName", "O primeiro nome deve conter pelo menos 3 caracteres")
            .IsLowerThan(StudentLastName, 45, "CreatePayPalSubscriptionCommand.StudentLastName", "O último nome não deve conter mais de 45 caracteres")
            .IsGreaterThan(StudentLastName, 3, "CreatePayPalSubscriptionCommand.StudentLastName", "O último nome deve conter pelo menos 3 caracteres")
        );
    }
}