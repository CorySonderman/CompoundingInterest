using System;

namespace CompoundingInterest
{
    public class Formula
    {
        public static double Solution(double principal, double annualReturn,
            int n, int years, double contributions)
        {
            double r = annualReturn / n;


            double retirement = principal * Math.Pow(1 + r, n * years);
            retirement += (contributions / r) * (Math.Pow(1 + r, n * years) - 1);

            return Math.Round(retirement);
        }
        // Calculate savings if started 10 years earlier
        public static double SolutionExtended10(int startingAge, double principal,
            double annualReturn, int n, int years, double contributions)
        {
            int yearsEarlier = 10;

            double retirementEarlier = Solution(principal, annualReturn, 1,
                years + yearsEarlier, contributions);

            return Math.Round(retirementEarlier);
        }
        // Calculate savings if started 20 years earlier
        public static double SolutionExtended20(int startingAge, double principal,
            double annualReturn, int n, int years, double contributions)
        {
            int twentyYears = 20;

            double finalRetirement = Solution(principal, annualReturn, 1,
                years + twentyYears, contributions);

            return Math.Round(finalRetirement);
        }
    }
}
