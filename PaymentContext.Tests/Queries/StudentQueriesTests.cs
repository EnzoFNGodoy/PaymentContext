using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Queries;
using PaymentContext.Tests.Data;
using PaymentContext.Tests.FakeData;

namespace PaymentContext.Tests.Queries;

public sealed class StudentQueriesTests
{
    private readonly IList<Student>? _students = StudentData.Students;

    [Fact]
    public void ShouldReturn_Error_When_Student_WithThis_CPF_NotExists()
    {
        var expression = StudentQueries.GetStudentByCPF("99999999999");
        var student = _students?.AsQueryable().Where(expression).FirstOrDefault();

        Assert.Null(student);
    }

    [Theory]
    [InlineData(DocumentsData.NEYMAR_DOCUMENT)]
    [InlineData(DocumentsData.CR7_DOCUMENT)]
    [InlineData(DocumentsData.MESSI_DOCUMENT)]
    public void ShouldReturn_Success_When_Student_WithThis_CPF_Exists(string document)
    {
        var expression = StudentQueries.GetStudentByCPF(document);
        var student = _students?.AsQueryable().Where(expression).FirstOrDefault();

        Assert.NotNull(student);
    }
}