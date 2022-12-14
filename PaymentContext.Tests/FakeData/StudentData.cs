using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Data;

namespace PaymentContext.Tests.FakeData;

public static class StudentData
{
    public static List<Student> Students = new()
    {
        new Student(
            new Name("Neymar", "Junior"),
            new Document(DocumentsData.NEYMAR_DOCUMENT, EDocumentType.CPF),
            new Email(EmailData.NEYMAR_EMAIL)
            ),
        new Student(
            new Name("Cristiano", "Ronaldo"),
            new Document(DocumentsData.CR7_DOCUMENT, EDocumentType.CPF),
            new Email(EmailData.CR7_EMAIL)
            ),
        new Student(
            new Name("Messi", "Junior"),
            new Document(DocumentsData.MESSI_DOCUMENT, EDocumentType.CPF),
            new Email(EmailData.MESSI_EMAIL)
            )
    };
}