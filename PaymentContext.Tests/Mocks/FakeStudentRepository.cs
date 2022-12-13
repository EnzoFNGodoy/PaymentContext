using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Tests.Data;

namespace PaymentContext.Tests.Mocks;

public sealed class FakeStudentRepository : IStudentRepository
{
    public bool DocumentExists(string document)
    {
        return document == DocumentsData.DOCUMENT_EXISTS;
    }

    public bool EmailExists(string email)
    {
        return email == EmailData.EMAIL_EXISTS;
    }

    public void CreateSubscription(Student student)
    {

    }
}