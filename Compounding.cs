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

    /// <summary>
    /// Equivalent to summing all future cash flows discounted to present day
    /// </summary>
    public static double Annuity(double lastCashFlow, double periods, double growthRate, double discountRate)
    {
        if (growthRate == discountRate)
            return periods * lastCashFlow;
        // Damodaran Little Book of Valuation p. 17
        var g = Math.Pow(1 + growthRate, periods);
        var d = Math.Pow(1 + discountRate, -periods);
        return lastCashFlow * (1 + growthRate) * (1 - g * d) / (discountRate - growthRate);
    }
}
