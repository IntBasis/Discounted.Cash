using static Unplugged.Core.CoreMath;

namespace Unplugged.SecurityAnalysis.Valuation
{
    public static class SimpleCashFlowDiscounting
    {
        public static double PresentValue(double futureCashFlow, double periods, double discountRate)
        {
            // Damodaran LBoV p. 15
            var discountFactor = DiscountFactor(discountRate, periods);
            return futureCashFlow * discountFactor;
        }
    }
}
