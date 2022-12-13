using PaymentContext.Domain.Services;

namespace PaymentContext.Tests.Mocks;

public sealed class FakeEmailServices : IEmailServices
{
    public void Send(string to, string email, string subject, string body)
    {
        
    }
}