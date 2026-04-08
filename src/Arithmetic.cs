namespace MathLibrary;

/// <summary>
/// Basic arithmetic operations.
/// </summary>
public static class Arithmetic
{
    public static double Add(double a, double b) => a + b;

    public static double Subtract(double a, double b) => a - b;

    public static double Multiply(double a, double b) => a * b;

    public static double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero.");
        return a / b;
    }

    public static double Modulo(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot compute modulo with divisor zero.");
        return a % b;
    }

    public static double Power(double baseVal, double exponent) => Math.Pow(baseVal, exponent);

    public static double SquareRoot(double value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Cannot take square root of a negative number.");
        return Math.Sqrt(value);
    }

    public static double AbsoluteValue(double value) => Math.Abs(value);

    public static double Factorial(int n)
    {
        if (n < 0)
            throw new ArgumentOutOfRangeException(nameof(n), "Factorial is not defined for negative numbers.");
        if (n == 0 || n == 1) return 1;
        double result = 1;
        for (int i = 2; i <= n; i++)
            result *= i;
        return result;
    }

    public static long GreatestCommonDivisor(long a, long b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public static long LeastCommonMultiple(long a, long b)
    {
        if (a == 0 || b == 0) return 0;
        return Math.Abs(a / GreatestCommonDivisor(a, b) * b);
    }

    public static bool IsPrime(int n)
    {
        if (n < 2) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;
        for (int i = 3; i * i <= n; i += 2)
            if (n % i == 0) return false;
        return true;
    }

    public static IEnumerable<int> Fibonacci(int count)
    {
        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Count must be positive.");
        int a = 0, b = 1;
        for (int i = 0; i < count; i++)
        {
            yield return a;
            (a, b) = (b, a + b);
        }
    }
}
