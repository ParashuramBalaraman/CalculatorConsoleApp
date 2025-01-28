class Calculator
{
    // Encapsulation as it hides the implementation details of the calculation from the user.
    private double Add(double num1, double num2)
    {
        return num1 + num2;
    }

    private double Subtract(double num1, double num2)
    {
        return num1 - num2;
    }

    private double Multiply(double num1, double num2)
    {
        return num1 * num2;
    }

    private double Divide(double num1, double num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }
        return num1 / num2;
    }

    public void Calculate(double num1, double num2, string operation)
    {
        double result;
        //Abstraction as the user does not need to know how the specific calculation is selected or how the output message is generated.
        switch (operation)
        {
            case "add":
                result = Add(num1, num2);
                break;
            case "sub":
                result = Subtract(num1, num2);
                break;
            case "mult":
                result = Multiply(num1, num2);
                break;
            case "div":
                result = Divide(num1, num2);
                break;
            default:
                throw new InvalidOperationException("Invalid operation");
        }
        Console.WriteLine($"Your result: {num1} {operation} {num2} = " + result);
        Console.Write("Press any key to close the Calculator console app...");
        Console.ReadKey();
    }
}

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
        Console.WriteLine("add - Addition");
        Console.WriteLine("sub - Subtraction");
        Console.WriteLine("mult - Multiplication");
        Console.WriteLine("div - Division");
        string operation = Console.ReadLine();
        string[] validOperations = { "add", "sub", "mult", "div" };
        while (!validOperations.Contains(operation))
        {
            Console.WriteLine("Please input a valid operation (add/sub/mult/div)");
            operation = Console.ReadLine();
        }
        return operation;
    }
}

 class Program //Figure out why this is partial and why I can't make it a normal class
{
    static void Main(string[] args)
    {
        // Follows the Single Responsibilty Principle as each class has a single responsibility. Rather than Calculator class doing the input validation as well.
        VerifyInput VerifyInput = new VerifyInput();
        Calculator calculator = new Calculator();

        // Abstraction as it hides the process of verifying whether the input is a valid number and operation.
        double num1 = VerifyInput.GetValidNumber("Please input first number");
        double num2 = VerifyInput.GetValidNumber("Please input second number");
        string operation = VerifyInput.GetValidOperation();

        calculator.Calculate(num1, num2, operation);
    }
}
