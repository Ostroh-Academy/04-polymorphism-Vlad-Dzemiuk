using System;

public class Function
{
    protected double[] coefficients;

    public Function(params double[] coefficients)
    {
        this.coefficients = coefficients;
    }

    public virtual void SetCoefficients(params double[] coefficients)
    {
        this.coefficients = coefficients;
    }

    public virtual void PrintCoefficients()
    {
        for (int i = 0; i < coefficients.Length; i++)
        {
            Console.WriteLine($"a{i}: {coefficients[i]}");
        }
    }

    public virtual double CalculateValue(double x)
    {
        double result = 0;
        for (int i = 0; i < coefficients.Length; i++)
        {
            result += coefficients[i] * Math.Pow(x, i);
        }
        return result;
    }
}

public class LinearFunction : Function
{
    public LinearFunction(double a1, double a0) : base(a0, a1)
    {
    }
}

public class Polynomial : Function
{
    public Polynomial(double a4, double a3, double a2, double a1, double a0) : base(a0, a1, a2, a3, a4)
    {
    }
}

public class FunctionFactory
{
    public static Function CreateFunction(int userChoice, double[] coefficients)
    {
        Function function = null;

        if (userChoice == 0)
        {
            function = new LinearFunction(coefficients[0], coefficients[1]);
        }
        else if (userChoice == 1)
        {
            function = new Polynomial(coefficients[4], coefficients[3], coefficients[2], coefficients[1], coefficients[0]);
        }

        return function;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Виберіть операцію:");
        Console.WriteLine("0 - робота з лінійною функцією");
        Console.WriteLine("1 - робота з многочленом");
        int userChoice = int.Parse(Console.ReadLine());

        if (userChoice == 0 || userChoice == 1)
        {
            double[] coefficients;

            if (userChoice == 0)
            {
                Console.WriteLine("Введіть коефіцієнти для лінійної функції (a1, a0): ");
                coefficients = new double[2];
            }
            else
            {
                Console.WriteLine("Введіть коефіцієнти полінома (a4, a3, a2, a1, a0): ");
                coefficients = new double[5];
            }

            for (int i = 0; i < coefficients.Length; i++)
            {
                coefficients[i] = double.Parse(Console.ReadLine());
            }

            Function function = FunctionFactory.CreateFunction(userChoice, coefficients);

            Console.WriteLine($"Введіть значення x для {(userChoice == 0 ? "лінійної функції" : "полінома")}: ");
            double x = double.Parse(Console.ReadLine());

            double result = function.CalculateValue(x);
            Console.WriteLine($"Значення {(userChoice == 0 ? "лінійної функції" : "полінома")} при {x}: {result}");
        }
        else
        {
            Console.WriteLine("Невірний вибір операції. Перевірте ввід.");
            return;
        }

        Console.ReadLine(); // Використовуйте цей рядок, щоб програма не закривалась відразу
    }
}