using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Helpers;

namespace PaymentContext.Tests.Validators;

public sealed class EnumValidatorTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
    [InlineData(13)]
    [InlineData(14)]
    [InlineData(15)]
    [InlineData(16)]
    [InlineData(17)]
    [InlineData(18)]
    [InlineData(19)]
    [InlineData(20)]
    [InlineData(21)]
    [InlineData(22)]
    [InlineData(23)]
    [InlineData(24)]
    [InlineData(25)]
    [InlineData(26)]
    [InlineData(27)]
    public void ShouldReturn_True(int enumValue)
    {
        Assert.True(EnumValidator<EState>.IsValid(enumValue));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(28)]
    public void ShouldReturn_False(int enumValue)
    {
        Assert.False(EnumValidator<EState>.IsValid(enumValue));
    }
}