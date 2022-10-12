using System.Runtime.CompilerServices;

namespace IntBasis.Apps.DiscountedCash;

public static class Compounding
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Compound(double cashFlow, double periods, double growthRate)
    {
        // Damodaran Little Book of Valuation p. 15 - 17
        // futureCashFlow = cashflow * (1 + growthRate)^n
        return cashFlow * Math.Pow(1 + growthRate, periods);
    }

    public static double Discount(double futureCashFlow, double periods, double discountRate)
    {
        // pv = futureCashflow / (1 + growthRate)^n
        return Compound(futureCashFlow, -periods, discountRate);
    }
}
