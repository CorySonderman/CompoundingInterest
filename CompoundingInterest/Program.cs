using CompoundingInterest;
using System;

class Program
{
    static void Main()
    {
        IntroPage introPage = new IntroPage();
        introPage.Intro();

        int currentAge = GetIntegerInput("Enter your current age: ");
        double principal = GetDoubleInput("Enter your initial investment: $");
        double annualReturnPercentage = GetDoubleInput("Enter the expected annualized return. Please do not type the % sign: ");
        annualReturnPercentage /= 100.0;
        int years = GetIntegerInput("Enter the number of years to calculate: ");
        double contributions = GetDoubleInput("Enter additional annual contributions (0 if none): $");
        Console.WriteLine();

        // Calculate savings with contributions
        double retirement = Formula.Solution(principal, annualReturnPercentage, years, contributions);

        // Calculate ending age
        int endingAge = currentAge + years;

        // Calculate total contributions
        double totalContributions = contributions * years + principal;

        // Calculate earnings
        double earnings = retirement - totalContributions;

        Console.Write($"If you start saving at age {currentAge}, your savings at age {endingAge} will be ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"{retirement:C}.  ");
        Console.ResetColor();
        Console.Write($"You will have invested ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"{totalContributions:C}");
        Console.ResetColor();
        Console.Write($" and earned ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"{earnings:C}.");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine();

        // calculation with starting 10 years earlier
        double retireEarlier = Formula.SolutionExtended10(currentAge - 10, principal, annualReturnPercentage, years, contributions);

        if (currentAge - 10 < 0)
        {
            Console.Write($"If you had started 10 years earlier, your savings at age {endingAge} would be ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{retireEarlier:C}.  ");
            Console.ResetColor();
            Console.Write($"That is an additional ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{retireEarlier - retirement:C}!");
            Console.ResetColor();
            Console.Write($" Obviously, for you to start at age {currentAge - 10}, your family would " +
                "have had to plan ahead.");
        }
        else
        {
            Console.Write($"If you had started 10 years earlier at age " +
                $"{currentAge - 10}, your savings at age {endingAge} would be ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{retireEarlier:C}.  ");
            Console.ResetColor();
            Console.Write($"That is an additional ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{retireEarlier - retirement:C}!");
            Console.ResetColor();
        }
        Console.WriteLine();
        Console.WriteLine();

        double finalRetirement = Formula.SolutionExtended20(currentAge - 20, principal, annualReturnPercentage, years, contributions);

        // calculation with starting 20 years earlier
        if (currentAge - 20 < 0)
        {
            Console.Write($"If you had started 20 years earlier, your savings at age {endingAge} would be ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{finalRetirement:C}.");
            Console.ResetColor();
            Console.Write($"That is an additional ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{finalRetirement - retirement:C}!");
            Console.ResetColor();
            Console.Write($" Obviously, for you to start at age {currentAge - 20}, your family would " +
                "have had to plan ahead.");
        }
        else
        {
            Console.Write($"If you had started 20 years earlier at age " +
                $"{currentAge - 20}, your savings at age {endingAge} would be ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{finalRetirement:C}.");
            Console.Write($"  That is an additional ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write($"{finalRetirement - retirement:C}!");
            Console.ResetColor();
        }
        Console.WriteLine();
        

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"You may not be able to go back in time but wouldn't " +
            $"now be a good time to start saving for your children?");
        Console.WriteLine();
        Console.ResetColor();
    }

    // in case of invalid input
    static int GetIntegerInput(string prompt)
    {
        int value;
        do
        {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out value));
        return value;
    }

    // in case of invalid input
    static double GetDoubleInput(string prompt)
    {
        double value;
        do
        {
            Console.Write(prompt);
        } while (!double.TryParse(Console.ReadLine(), out value));
        return value;
    }
}
