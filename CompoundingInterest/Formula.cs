using System;

namespace CompoundingInterest
{
    public class Formula
    {
        public static double Solution(double principal, double annualReturn, int years, double contributions)
        {
            double interestRate = annualReturn;


            double retirement = principal * Math.Pow(1 + interestRate, years);
            retirement += (contributions / interestRate) * (Math.Pow(1 + interestRate, years) - 1);

            return Math.Round(retirement);
        }
        // Calculate savings if started 10 years earlier
        public static double SolutionExtended10(int startingAge, double principal,
            double annualReturn, int years, double contributions)
            
        {
            int yearsEarlier = 10;

            double retirementEarlier = Solution(principal, annualReturn,
                years + yearsEarlier, contributions);

            return Math.Round(retirementEarlier);
        }
        // Calculate savings if started 20 years earlier
        public static double SolutionExtended20(int startingAge, double principal,
            double annualReturn, int years, double contributions)
        {
            int twentyYears = 20;

            double finalRetirement = Solution(principal, annualReturn,
                years + twentyYears, contributions);

            return Math.Round(finalRetirement);
        }
    }
}
