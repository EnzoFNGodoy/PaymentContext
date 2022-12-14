using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using System.Linq.Expressions;

namespace PaymentContext.Domain.Queries;

public sealed class StudentQueries
{
    public static Expression<Func<Student, bool>> GetStudentByCPF(string cpfDocument)
    {
        return x => x.Document.Number == cpfDocument
        && x.Document.Type == EDocumentType.CPF;
    }
}