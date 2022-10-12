namespace IntBasis.Apps.DiscountedCash;

public static class Parsing
{
    public static double ToDouble(object? value)
    {
        if (string.IsNullOrWhiteSpace(value as string))
            return 0;
        return Convert.ToDouble(value);
    }
}
