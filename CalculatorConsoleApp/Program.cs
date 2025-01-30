using System;
using System.Linq.Expressions;

namespace CalculatorNS
{
    public interface ICalculator
    {
        // Calculate is still behaviour of the calculator and is a public method
        double Calculate(double num1, double num2, string operation);
    }

    public abstract class AbstractCalculator
    {
        // Encapsulation as it hides the implementation details of the calculation from the user.
        protected double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        protected double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        protected double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        protected double Divide(double num1, double num2)
        {
            return num1 / num2;
        }
    }


    public class Calculator : AbstractCalculator, ICalculator
    {
        public double Calculate(double num1, double num2, string operation)
        {
            double result;

            // Validate divisor before performing division
            if (operation == "4" && num2 == 0)
            {
                // Single Responsibility Principle as the input validation is separated from the calculation logic.
                num2 = new VerifyInput().GetValidDivisor();
            }

            //Error handling for any invalid operation using the try and catch block.
            try
            {
                //Abstraction as the user does not need to know how the specific calculation is selected or how the output message is generated.
                switch (operation)
                {
                    case "1":
                        result = Add(num1, num2);
                        operation = "+";
                        break;
                    case "2":
                        result = Subtract(num1, num2);
                        operation = "-";
                        break;
                    case "3":
                        result = Multiply(num1, num2);
                        operation = "*";
                        break;
                    case "4":
                        result = Divide(num1, num2);
                        operation = "/";
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operation");
                }
                result = Math.Round(result, 4);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"The following error occured: {e.Message}");
                return 0;
            }
        }
    }

    //Maybe needs an abstract class
    class VerifyInput
    {
        // Abstraction as the user does not need to know how the inputs are validated.
        public double GetValidNumber(string input)
        {
            double number;
            Console.WriteLine(input);
            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Please input a valid number");
            }
            return number;
        }
        public string GetValidOperation()
        {
            Console.WriteLine("Please choose one of the following operations:");
            Console.WriteLine("1 - Addition");
            Console.WriteLine("2 - Subtraction");
            Console.WriteLine("3 - Multiplication");
            Console.WriteLine("4 - Division");
            string operation = Console.ReadLine();
            string[] validOperations = { "1", "2", "3", "4" };
            while (!validOperations.Contains(operation))
            {
                Console.WriteLine("Please input a valid operation (1/2/3/4)");
                operation = Console.ReadLine();
            }
            return operation;
        }

        public double GetValidDivisor()
        {
            double divisor = GetValidNumber("Divisor cannot be zero. Please input a valid divisor");
            while (divisor == 0)
            {
                divisor = GetValidNumber("Divisor cannot be zero. Please input a valid divisor");
            }
            return divisor;
        }
    }

    class EndOfCalculation
    {
        public void ResultOutput(double num1, double num2, string operation, double result)
        {
            string symbol = "";
            if (operation == "1")
            {
                symbol = "+";
            }
            else if (operation == "2")
            {
                symbol = "-";
            }
            else if (operation == "3")
            {
                symbol = "*";
            }
            else if (operation == "4")
            {
                symbol = "/";
            }
            Console.WriteLine($"Your result: {num1} {symbol} {num2} = " + result);
        }
        // Abstraction as the user does not need to know how the output message is generated.
        public bool ContinueOrExit()
        {
            Console.WriteLine("Please input 'y' to continue or 'n' to exit");
            string response = Console.ReadLine();
            while (response != "y" && response != "n")
            {
                Console.WriteLine("Invalid input. Please input 'y' to continue or 'n' to exit");
                response = Console.ReadLine();
            }
            if (response == "y")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Thanks for using the calculator.");
                return false;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Follows the Single Responsibilty Principle as each class has a single responsibility. Rather than Calculator class doing the input validation as well.
            VerifyInput VerifyInput = new VerifyInput();
            Calculator calculator = new Calculator();
            EndOfCalculation EndOfCalculation = new EndOfCalculation();
            bool continueCalculation = true;
            double result;

            while (continueCalculation)
            {
                // Abstraction as it hides the process of verifying whether the input is a valid number and operation.
                string operation = VerifyInput.GetValidOperation();
                double num1 = VerifyInput.GetValidNumber("Please input first number");
                double num2 = VerifyInput.GetValidNumber("Please input second number");

                result = calculator.Calculate(num1, num2, operation);
                EndOfCalculation.ResultOutput(num1, num2, operation, result);
                continueCalculation = EndOfCalculation.ContinueOrExit();
            }
        }
    }
}
