using PaymentContext.Domain.Commands;

namespace PaymentContext.Tests.Commands;

public sealed class CreateBoletoSubscriptionCommandTests
{
    [Theory]
    [InlineData("", "Messi")]
    [InlineData("Lionel", "")]
    public void ShouldReturn_Error_When_Name_IsInvalid(string studentFirstName, string studentLastName)
    {
        var command = new CreateBoletoSubscriptionCommand
        {
            StudentFirstName = studentFirstName,
            StudentLastName = studentLastName
        };

        command.Validate();
        Assert.Equal(false, command.IsValid);
    }
}