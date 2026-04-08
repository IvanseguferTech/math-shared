namespace MathLibrary;

/// <summary>
/// Algebraic operations: logarithms, polynomials, sequences and number theory.
/// </summary>
public static class Algebra
{
    // ── Logaritmos / exponenciales ────────────────────────────────────────────

    public static double Log(double value, double newBase = Math.E)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Logarithm input must be positive.");
        if (newBase <= 0 || newBase == 1)
            throw new ArgumentOutOfRangeException(nameof(newBase), "Base must be positive and not equal to 1.");
        return Math.Log(value, newBase);
    }

    public static double Log10(double value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Log10 input must be positive.");
        return Math.Log10(value);
    }

    public static double NaturalLog(double value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Natural log input must be positive.");
        return Math.Log(value);
    }

    public static double Exp(double value) => Math.E * Math.Pow(Math.E, value - 1); // e^value

    // ── Ecuación cuadrática ───────────────────────────────────────────────────

    /// <summary>
    /// Solves ax² + bx + c = 0 using the quadratic formula.
    /// Returns up to two real roots; throws if no real solution exists.
    /// </summary>
    public static (double Root1, double Root2) QuadraticRoots(double a, double b, double c)
    {
        if (a == 0) throw new ArgumentException("Coefficient 'a' must not be zero for a quadratic equation.");
        double discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
            throw new InvalidOperationException($"No real roots: discriminant = {discriminant}");
        double sqrtD = Math.Sqrt(discriminant);
        return ((-b + sqrtD) / (2 * a), (-b - sqrtD) / (2 * a));
    }

    public static double QuadraticDiscriminant(double a, double b, double c) => b * b - 4 * a * c;

    // ── Progresión aritmética / geométrica ────────────────────────────────────

    /// <summary>n-th term of arithmetic sequence: a + (n-1)*d</summary>
    public static double ArithmeticTerm(double first, double commonDifference, int n)
    {
        if (n < 1) throw new ArgumentOutOfRangeException(nameof(n), "n must be >= 1.");
        return first + (n - 1) * commonDifference;
    }

    /// <summary>Sum of first n terms of an arithmetic sequence.</summary>
    public static double ArithmeticSum(double first, double commonDifference, int n)
    {
        if (n < 1) throw new ArgumentOutOfRangeException(nameof(n), "n must be >= 1.");
        return n / 2.0 * (2 * first + (n - 1) * commonDifference);
    }

    /// <summary>n-th term of geometric sequence: a * r^(n-1)</summary>
    public static double GeometricTerm(double first, double commonRatio, int n)
    {
        if (n < 1) throw new ArgumentOutOfRangeException(nameof(n), "n must be >= 1.");
        return first * Math.Pow(commonRatio, n - 1);
    }

    /// <summary>Sum of first n terms of a geometric sequence.</summary>
    public static double GeometricSum(double first, double commonRatio, int n)
    {
        if (n < 1) throw new ArgumentOutOfRangeException(nameof(n), "n must be >= 1.");
        if (commonRatio == 1) return first * n;
        return first * (1 - Math.Pow(commonRatio, n)) / (1 - commonRatio);
    }

    // ── Combinatoria ──────────────────────────────────────────────────────────

    /// <summary>Combinations: C(n, k) = n! / (k! * (n-k)!)</summary>
    public static long Combinations(int n, int k)
    {
        if (n < 0 || k < 0) throw new ArgumentOutOfRangeException("n and k must be non-negative.");
        if (k > n) return 0;
        if (k == 0 || k == n) return 1;
        k = Math.Min(k, n - k);
        long result = 1;
        for (int i = 0; i < k; i++)
        {
            result = result * (n - i) / (i + 1);
        }
        return result;
    }

    /// <summary>Permutations: P(n, k) = n! / (n-k)!</summary>
    public static long Permutations(int n, int k)
    {
        if (n < 0 || k < 0) throw new ArgumentOutOfRangeException("n and k must be non-negative.");
        if (k > n) return 0;
        long result = 1;
        for (int i = n; i > n - k; i--)
            result *= i;
        return result;
    }

    // ── Evaluación de polinomio ───────────────────────────────────────────────

    /// <summary>
    /// Evaluates a polynomial with given coefficients at x.
    /// Coefficients are ordered from highest to lowest degree.
    /// e.g. coefficients [2, -3, 1] = 2x² - 3x + 1
    /// </summary>
    public static double EvaluatePolynomial(double x, double[] coefficients)
    {
        if (coefficients == null || coefficients.Length == 0)
            throw new ArgumentException("Coefficients must not be empty.");
        double result = 0;
        foreach (double coef in coefficients)
            result = result * x + coef;
        return result;
    }

    // ── Interés ───────────────────────────────────────────────────────────────

    /// <summary>Simple interest: P * r * t</summary>
    public static double SimpleInterest(double principal, double rate, double time)
    {
        if (principal < 0) throw new ArgumentOutOfRangeException(nameof(principal));
        if (rate < 0) throw new ArgumentOutOfRangeException(nameof(rate));
        if (time < 0) throw new ArgumentOutOfRangeException(nameof(time));
        return principal * rate * time;
    }

    /// <summary>Compound interest: P * (1 + r/n)^(n*t)</summary>
    public static double CompoundInterest(double principal, double rate, double time, int n = 1)
    {
        if (principal < 0) throw new ArgumentOutOfRangeException(nameof(principal));
        if (rate < 0) throw new ArgumentOutOfRangeException(nameof(rate));
        if (time < 0) throw new ArgumentOutOfRangeException(nameof(time));
        if (n <= 0) throw new ArgumentOutOfRangeException(nameof(n));
        return principal * Math.Pow(1 + rate / n, n * time);
    }
}
