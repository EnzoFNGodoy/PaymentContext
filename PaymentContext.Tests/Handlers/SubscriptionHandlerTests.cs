using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Data;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers;

public sealed class SubscriptionHandlerTests
{
    #region BoletoSubscriptionCommand
    [Fact]
    public void BoletoSubscriptionCommand_ShouldReturn_Error_When_EmailExists()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailServices());
        var command = new CommandsData().BoletoSubscriptionCommand;
        command.StudentEmail = EmailData.EMAIL_EXISTS;

        handler.Handle(command);
        Assert.False(handler.IsValid);
    }
    
    [Fact]
    public void BoletoSubscriptionCommand_ShouldReturn_Error_When_DocumentExists()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailServices());
        var command = new CommandsData().BoletoSubscriptionCommand;
        command.StudentDocument = DocumentsData.DOCUMENT_EXISTS;

        handler.Handle(command);
        Assert.False(handler.IsValid);
    }

    [Fact]
    public void BoletoSubscriptionCommand_ShouldReturn_Success_When_AllIsCorrect()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailServices());
        var command = new CommandsData().BoletoSubscriptionCommand;

        handler.Handle(command);
        Assert.True(handler.IsValid);
    }
    #endregion
    
    #region PayPalSubscriptionCommand
    [Fact]
    public void PayPalSubscriptionCommand_ShouldReturn_Error_When_EmailExists()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailServices());
        var command = new CommandsData().PayPalSubscriptionCommand;
        command.StudentEmail = EmailData.EMAIL_EXISTS;

        handler.Handle(command);
        Assert.False(handler.IsValid);
    }
    
    [Fact]
    public void PayPalSubscriptionCommand_ShouldReturn_Error_When_DocumentExists()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailServices());
        var command = new CommandsData().PayPalSubscriptionCommand;
        command.StudentDocument = DocumentsData.DOCUMENT_EXISTS;

        handler.Handle(command);
        Assert.False(handler.IsValid);
    }

    [Fact]
    public void PayPalSubscriptionCommand_ShouldReturn_Success_When_AllIsCorrect()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailServices());
        var command = new CommandsData().PayPalSubscriptionCommand;

        handler.Handle(command);
        Assert.True(handler.IsValid);
    }
    #endregion
    
    #region CreditCardSubscriptionCommand
    [Fact]
    public void CreditCardSubscriptionCommand_ShouldReturn_Error_When_EmailExists()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailServices());
        var command = new CommandsData().CreditCardSubscriptionCommand;
        command.StudentEmail = EmailData.EMAIL_EXISTS;

        handler.Handle(command);
        Assert.False(handler.IsValid);
    }
    
    [Fact]
    public void CreditCardSubscriptionCommand_ShouldReturn_Error_When_DocumentExists()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailServices());
        var command = new CommandsData().CreditCardSubscriptionCommand;
        command.StudentDocument = DocumentsData.DOCUMENT_EXISTS;

        handler.Handle(command);
        Assert.False(handler.IsValid);
    }

    [Fact]
    public void CreditCardSubscriptionCommand_ShouldReturn_Success_When_AllIsCorrect()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailServices());
        var command = new CommandsData().CreditCardSubscriptionCommand;

        handler.Handle(command);
        Assert.True(handler.IsValid);
    }
    #endregion
}