namespace PaymentContext.Shared.Helpers;

public static class EnumValidator<TEnum> where TEnum : Enum
{
    private static readonly int _enumMinValue = Enum.GetValues(typeof(TEnum)).GetLowerBound(0)+1;
    private static readonly int _enumMaxValue = Enum.GetValues(typeof(TEnum)).GetUpperBound(0)+1;

    public static bool IsValid(int enumValue)
    {
        bool isLowerThanMinValue = enumValue < _enumMinValue;
        bool isGreaterThanMaxValue = enumValue > _enumMaxValue;

        if (isLowerThanMinValue || isGreaterThanMaxValue)
            return false;

        return true;
    }
}
