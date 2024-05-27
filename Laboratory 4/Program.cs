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

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Виберіть операцію:");
        Console.WriteLine("0 - робота з лінійною функцією");
        Console.WriteLine("1 - робота з многочленом");
        int userChoice = int.Parse(Console.ReadLine());

        Function function;

        if (userChoice == 0)
        {
            Console.WriteLine("Введіть коефіцієнти для лінійної функції (a1, a0): ");
            double a1 = double.Parse(Console.ReadLine());
            double a0 = double.Parse(Console.ReadLine());

            function = new LinearFunction(a1, a0);

            Console.WriteLine("Введіть значення x для лінійної функції: ");
            double xLinear = double.Parse(Console.ReadLine());

            double linearFunctionValue = function.CalculateValue(xLinear);
            Console.WriteLine($"Значення лінійної функції при {xLinear}: {linearFunctionValue}");
        }
        else if (userChoice == 1)
        {
            Console.WriteLine("Введіть коефіцієнти полінома (a4, a3, a2, a1, a0): ");
            double a4 = double.Parse(Console.ReadLine());
            double a3 = double.Parse(Console.ReadLine());
            double a2 = double.Parse(Console.ReadLine());
            double a1 = double.Parse(Console.ReadLine());
            double a0 = double.Parse(Console.ReadLine());

            function = new Polynomial(a4, a3, a2, a1, a0);

            Console.WriteLine("Введіть значення x для полінома: ");
            double xPoly = double.Parse(Console.ReadLine());

            double polynomialValue = function.CalculateValue(xPoly);
            Console.WriteLine($"Значення полінома при {xPoly}: {polynomialValue}");
        }
        else
        {
            Console.WriteLine("Невірний вибір операції. Перевірте ввід.");
            return;
        }
    }
}