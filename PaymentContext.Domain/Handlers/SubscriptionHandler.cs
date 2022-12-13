using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers;

public sealed class SubscriptionHandler :
    Notifiable<Notification>,
    IHandler<CreateBoletoSubscriptionCommand>,
    IHandler<CreatePayPalSubscriptionCommand>,
    IHandler<CreateCreditCardSubscriptionCommand>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IEmailServices _emailServices;

    public SubscriptionHandler(
        IStudentRepository studentRepository,
        IEmailServices emailServices)
    {
        _studentRepository = studentRepository;
        _emailServices = emailServices;
    }

    public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
    {
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar sua assinatura");
        }

        // Verificar se documento já está cadastrado
        if (_studentRepository.DocumentExists(command.StudentDocument))
            AddNotification("Document", "Esse CPF já está em uso");

        // Verificar se email já está cadastrado 
        if (_studentRepository.EmailExists(command.StudentEmail))
            AddNotification("Email", "Esse email já está em uso");

        // Gerar os VOs
        var name = new Name(command.StudentFirstName, command.StudentLastName);
        var document = new Document(command.StudentDocument, EDocumentType.CPF);
        var email = new Email(command.StudentEmail);
        var address = new Address(
            command.PayerNeighborhood,
            command.PayerStreet,
            command.PayerNumber,
            command.PayerZipCode,
            command.PayerCity,
            command.PayerState,
            command.PayerCountry);

        // Gerar as entidades
        var student = new Student(name, document, email);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));
        var payerDocument = new Document(command.PayerDocument, command.PayerDocumentType);
        var payment = new BoletoPayment(
            command.BarCode,
            command.BoletoNumber,
            command.PaymentDate,
            command.ExpirationDate,
            command.Total,
            command.TotalPaid,
            command.Payer,
            payerDocument,
            address,
            email);

        // Relacionamentos
        subscription.AddPayment(payment);
        student.AddSubscription(subscription);

        // Agrupar as validações
        AddNotifications(name, document, email, address, student, subscription, payment);

        // Checar validações
        if (!IsValid)
            return new CommandResult(false, "Não foi possível realizar sua assinatura");

        // Salvar as informações
        _studentRepository.CreateSubscription(student);

        // Enviar email de boas vindas
        _emailServices.Send(name.ToString(), email.ToString(), "Bem-vindo ao godoy.io", "Sua assinatura foi criada.");

        // Retornar informações
        return new CommandResult(true, "Assinatura realizada com sucesso");
    }

    public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
    {
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar sua assinatura");
        }

        // Verificar se documento já está cadastrado
        if (_studentRepository.DocumentExists(command.StudentDocument))
            AddNotification("Document", "Esse CPF já está em uso");

        // Verificar se email já está cadastrado 
        if (_studentRepository.EmailExists(command.StudentEmail))
            AddNotification("Email", "Esse email já está em uso");

        // Gerar os VOs
        var name = new Name(command.StudentFirstName, command.StudentLastName);
        var document = new Document(command.StudentDocument, EDocumentType.CPF);
        var email = new Email(command.StudentEmail);
        var address = new Address(
            command.PayerNeighborhood,
            command.PayerStreet,
            command.PayerNumber,
            command.PayerZipCode,
            command.PayerCity,
            command.PayerState,
            command.PayerCountry);

        // Gerar as entidades
        var student = new Student(name, document, email);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));
        var payerDocument = new Document(command.PayerDocument, command.PayerDocumentType);
        var payment = new PayPalPayment(
            command.TransactionCode,
            command.PaymentDate,
            command.ExpirationDate,
            command.Total,
            command.TotalPaid,
            command.Payer,
            payerDocument,
            address,
            email);

        // Relacionamentos
        subscription.AddPayment(payment);
        student.AddSubscription(subscription);

        // Agrupar as validações
        AddNotifications(name, document, email, address, student, subscription, payment);

        // Checar validações
        if (!IsValid)
            return new CommandResult(false, "Não foi possível realizar sua assinatura");

        // Salvar as informações
        _studentRepository.CreateSubscription(student);

        // Enviar email de boas vindas
        _emailServices.Send(name.ToString(), email.ToString(), "Bem-vindo ao godoy.io", "Sua assinatura foi criada.");

        // Retornar informações
        return new CommandResult(true, "Assinatura realizada com sucesso");
    }

    public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
    {
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar sua assinatura");
        }

        // Verificar se documento já está cadastrado
        if (_studentRepository.DocumentExists(command.StudentDocument))
            AddNotification("Document", "Esse CPF já está em uso");

        // Verificar se email já está cadastrado 
        if (_studentRepository.EmailExists(command.StudentEmail))
            AddNotification("Email", "Esse email já está em uso");

        // Gerar os VOs
        var name = new Name(command.StudentFirstName, command.StudentLastName);
        var document = new Document(command.StudentDocument, EDocumentType.CPF);
        var email = new Email(command.StudentEmail);
        var address = new Address(
            command.PayerNeighborhood,
            command.PayerStreet,
            command.PayerNumber,
            command.PayerZipCode,
            command.PayerCity,
            command.PayerState,
            command.PayerCountry);

        // Gerar as entidades
        var student = new Student(name, document, email);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));
        var payerDocument = new Document(command.PayerDocument, command.PayerDocumentType);
        var payment = new CreditCardPayment(
            command.CardHolderName,
            command.CardNumber,
            command.LastTransactionNumber,
            command.PaymentDate,
            command.ExpirationDate,
            command.Total,
            command.TotalPaid,
            command.Payer,
            payerDocument,
            address,
            email);

        // Relacionamentos
        subscription.AddPayment(payment);
        student.AddSubscription(subscription);

        // Agrupar as validações
        AddNotifications(name, document, email, address, student, subscription, payment);

        // Checar validações
        if (!IsValid)
            return new CommandResult(false, "Não foi possível realizar sua assinatura");

        // Salvar as informações
        _studentRepository.CreateSubscription(student);

        // Enviar email de boas vindas
        _emailServices.Send(name.ToString(), email.ToString(), "Bem-vindo ao godoy.io", "Sua assinatura foi criada.");

        // Retornar informações
        return new CommandResult(true, "Assinatura realizada com sucesso");
    }
}