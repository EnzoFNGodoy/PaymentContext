using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

public class DocumentTests
{
    #region CNPJ
    [Theory]
    [InlineData("123")]
    [InlineData("1233012973091728123")]
    public void ShouldReturn_Error_When_CNPJ_IsInvalid(string cnpjNumber)
    {
        var doc = new Document(cnpjNumber, EDocumentType.CNPJ);

        Assert.False(doc.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_When_CNPJ_IsValid()
    {
        var validCNPJ = "14509717000178";
        var doc = new Document(validCNPJ, EDocumentType.CNPJ);

        Assert.True(doc.IsValid);
    }
    #endregion

    #region CPF
    [Theory]
    [InlineData("123")]
    [InlineData("1233012973091728123")]
    public void ShouldReturn_Error_When_CPF_IsInvalid(string cpfNumber)
    {
        var doc = new Document(cpfNumber, EDocumentType.CPF);

        Assert.False(doc.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_When_CPF_IsValid()
    {
        var validCPF = "51347666060";
        var doc = new Document(validCPF, EDocumentType.CPF);

        Assert.True(doc.IsValid);
    }
    #endregion
}