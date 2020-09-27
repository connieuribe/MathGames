using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Threading;

namespace MathGames
{
    class Program
    {
        static int Add(int n)
        {
            int count = 0;
            String[] expressions = new String[n];
            for (int i = 0; i < expressions.Length; i++)
            {
                Console.Write($"{count + 1}. ");
                string str = Console.ReadLine();
                expressions[i] = str;
                count++;
            }
            String pattern = @"(\d+)\s+([+])\s+(\d+)\s+([=])\s+(\d+)";
            count = 0;
            foreach (var expression in expressions)
                foreach (System.Text.RegularExpressions.Match m in
                System.Text.RegularExpressions.Regex.Matches(expression, pattern))
                {
                    int value1 = Int32.Parse(m.Groups[1].Value);
                    int value2 = Int32.Parse(m.Groups[3].Value);
                    int value3 = Int32.Parse(m.Groups[5].Value);
                    if (value1 + value2 == value3)
                    {
                        count++;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry the addition of {value1} and {value2} is {value3}");
                    }

                }

            return count;
        }
        static int Subtract(int n) //always positive
        {
            int count = 0;
            String[] expressions = new String[n];
            for (int i = 0; i < expressions.Length; i++)
            {
                Console.Write($"{count + 1}. ");
                string str = Console.ReadLine();
                expressions[i] = str;
                count++;
            }
            String pattern = @"(\d+)\s+([-])\s+(\d+)\s+([=])\s+(\d+)";
            count = 0;
            foreach (var expression in expressions)
                foreach (System.Text.RegularExpressions.Match m in
                System.Text.RegularExpressions.Regex.Matches(expression, pattern))
                {
                    int value1 = Int32.Parse(m.Groups[1].Value);
                    int value2 = Int32.Parse(m.Groups[3].Value);
                    int value3 = Int32.Parse(m.Groups[5].Value);
                    if(value1-value2 == value3)
                    {
                        count++;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry the subtraction of {value1} and {value2} is {value3}" );
                    }
                    
                }
            
            return count;
        }
        static int Multiply(int n)
        {
            int count = 0;
            String[] expressions = new String[n];
            for (int i = 0; i < expressions.Length; i++)
            {
                Console.Write($"{count + 1}. ");
                string str = Console.ReadLine();
                expressions[i] = str;
                count++;
            }
            String pattern = @"(\d+)\s+([*])\s+(\d+)\s+([=])\s+(\d+)";
            count = 0;
            foreach (var expression in expressions)
                foreach (System.Text.RegularExpressions.Match m in
                System.Text.RegularExpressions.Regex.Matches(expression, pattern))
                {
                    int value1 = Int32.Parse(m.Groups[1].Value);
                    int value2 = Int32.Parse(m.Groups[3].Value);
                    int value3 = Int32.Parse(m.Groups[5].Value);
                    if (value1 * value2 == value3)
                    {
                        count++;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry the multiplication of {value1} and {value2} is {value3}");
                    }

                }

            return count;
        }
        static int Divide(int n)
        {
            int count = 0;
            String[] expressions = new String[n];
            for (int i = 0; i < expressions.Length; i++)
            {
                Console.Write($"{count + 1}. ");
                string str = Console.ReadLine();
                expressions[i] = str;
                count++;
            }
            String pattern = @"(\d+)\s+([/])\s+(\d+)\s+([=])\s+(\d+)";
            count = 0;
            foreach (var expression in expressions)
                foreach (System.Text.RegularExpressions.Match m in
                System.Text.RegularExpressions.Regex.Matches(expression, pattern))
                {
                    int value1 = Int32.Parse(m.Groups[1].Value);
                    int value2 = Int32.Parse(m.Groups[3].Value);
                    int value3 = Int32.Parse(m.Groups[5].Value);
                    if (value1 / value2 == value3)
                    {
                        count++;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry the division of {value1} and {value2} is {value3}");
                    }

                }

            return count;
        }
        static string Report(int score, int numProb)
        {
            return $"You got {score} out of {numProb} and your grade is {(score / numProb)*100}.";
        }
        static (int, int) Initialize()
        {
            Console.WriteLine("Welcome to Math Games");
            Console.WriteLine("\tTo add, enter 1, \n" +
                              "\tTo subtract, enter 2, \n" +
                              "\tTo multiply, enter 3, \n" +
                              "\tTo divide, enter 4");
            Console.Write("Choose your problem type: ");
            int probType = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter number of problems between 1 and 12: ");
            int numProb = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return (probType, numProb);
        }
        static void Main(string[] args) 
        {
            try
            {
                int probType = 0;
                int numProb = 0;
                int score = 0;
                (probType, numProb) = Initialize();
                switch(probType)
                {
                    case (1):
                        Console.WriteLine($"You are testing Addition and you have {numProb} problems");
                        score = Add(numProb);
                        break;
                    case (2):
                        Console.WriteLine($"You are testing Subtration and you have {numProb} problems:");
                        score = Subtract(numProb);
                        break;
                    case (3):
                        Console.WriteLine($"You are testing Multiplication and you have {numProb} problems:");
                        score = Multiply(numProb);
                        break;
                    case (4):
                        Console.WriteLine($"You are testing Division and you have {numProb} problems:");
                        score = Divide(numProb);
                        break;
                    default:
                        Console.WriteLine("Sorry, you made an invalid choice.");
                        return;
                }
                string report = Report(score, numProb);
                Console.WriteLine(report);
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
