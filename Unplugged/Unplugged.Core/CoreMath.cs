using System;
using System.Runtime.CompilerServices;

namespace Unplugged.Core
{
    public static class CoreMath
    {
        public static double ClampPositive(double x) => (x < 0) ? 0 : x;

        /// <summary>
        /// e^x
        /// </summary>
        public static double Exp(double x) => Math.Pow(Math.E, x);

        public static bool AlmostEqual(double a, double b, double epsilon) =>
            Math.Abs(a - b) <= epsilon;

        /// <summary>
        /// (1 + r)^n
        /// </summary>
        /// <param name="rate">r</param>
        /// <param name="periods">n</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CompoundFactor(double rate, double periods)
        {
            return Math.Pow(1 + rate, periods);
        }

        /// <summary>
        /// (1 + r)^(-n)
        /// </summary>
        /// <param name="rate">r</param>
        /// <param name="periods">n</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DiscountFactor(double rate, double periods)
        {
            return CompoundFactor(rate, -periods);
        }

        public static double CumulativeNormalDensity(double z)
        {
            // https://en.wikipedia.org/wiki/Standard_normal_table#Cumulative
            // =NORMSDIST
            // same as NORM.S.DIST(Z, TRUE)
            // HACK: Using a Look-up Table:
            if (z < 0 || z > 1)
                return z;
            //throw new NotImplementedException("Cumulative normal density not implemented outside of z = 0...1");
            var table = new[] {
                (0.0, 0.5),
                (0.1, 0.539827837),
                (0.2, 0.579259709),
                (0.3, 0.617911422),
                (0.4, 0.655421742),
                (0.5, 0.691462461),
                (0.6, 0.725746882),
                (0.7, 0.758036348),
                (0.8, 0.788144601),
                (0.9, 0.815939875),
                (1.0, 0.841344746),
                (1.1, 0.864333939)
            };
            var index = (int)Math.Floor(z * 10);
            var t = z * 10 - index;
            var a = table[index].Item2;
            var b = table[index + 1].Item2;
            return LinearInterpolate(a, b, t);

            // Normal distribution function:
            // https://en.wikipedia.org/wiki/Cumulative_distribution_function
            // https://support.office.com/en-us/article/normsdist-function-463369ea-0345-445d-802a-4ff0d6ce7cac
            // https://influentialpoints.com/notes/n3normfm.htm
            // return Math.Pow(Math.E, -(z * z) / 2) / Math.Sqrt(2 * Math.PI);
        }

        public static double LinearInterpolate(double a, double b, double t)
        {
            return a + (b - a) * t;
        }
    }
}
