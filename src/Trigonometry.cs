namespace MathLibrary;

/// <summary>
/// Trigonometric functions and angle conversions.
/// </summary>
public static class Trigonometry
{
    // ── Conversiones ─────────────────────────────────────────────────────────

    public static double DegreesToRadians(double degrees) => degrees * Math.PI / 180.0;

    public static double RadiansToDegrees(double radians) => radians * 180.0 / Math.PI;

    // ── Funciones primarias ───────────────────────────────────────────────────

    public static double Sin(double degrees) => Math.Sin(DegreesToRadians(degrees));

    public static double Cos(double degrees) => Math.Cos(DegreesToRadians(degrees));

    public static double Tan(double degrees)
    {
        double rad = DegreesToRadians(degrees);
        if (Math.Abs(Math.Cos(rad)) < 1e-10)
            throw new InvalidOperationException($"Tangent is undefined at {degrees}°.");
        return Math.Tan(rad);
    }

    // ── Funciones inversas ────────────────────────────────────────────────────

    public static double ArcSin(double value)
    {
        if (value < -1 || value > 1)
            throw new ArgumentOutOfRangeException(nameof(value), "ArcSin input must be in [-1, 1].");
        return RadiansToDegrees(Math.Asin(value));
    }

    public static double ArcCos(double value)
    {
        if (value < -1 || value > 1)
            throw new ArgumentOutOfRangeException(nameof(value), "ArcCos input must be in [-1, 1].");
        return RadiansToDegrees(Math.Acos(value));
    }

    public static double ArcTan(double value) => RadiansToDegrees(Math.Atan(value));

    public static double ArcTan2(double y, double x) => RadiansToDegrees(Math.Atan2(y, x));

    // ── Funciones recíprocas ──────────────────────────────────────────────────

    public static double Csc(double degrees)
    {
        double s = Sin(degrees);
        if (Math.Abs(s) < 1e-10)
            throw new InvalidOperationException($"Cosecant is undefined at {degrees}°.");
        return 1.0 / s;
    }

    public static double Sec(double degrees)
    {
        double c = Cos(degrees);
        if (Math.Abs(c) < 1e-10)
            throw new InvalidOperationException($"Secant is undefined at {degrees}°.");
        return 1.0 / c;
    }

    public static double Cot(double degrees)
    {
        double t = Sin(degrees);
        if (Math.Abs(t) < 1e-10)
            throw new InvalidOperationException($"Cotangent is undefined at {degrees}°.");
        return Cos(degrees) / t;
    }

    // ── Hiperbólicas ─────────────────────────────────────────────────────────

    public static double Sinh(double value) => Math.Sinh(value);

    public static double Cosh(double value) => Math.Cosh(value);

    public static double Tanh(double value) => Math.Tanh(value);

    // ── Identidades / utilidades ──────────────────────────────────────────────

    /// <summary>Distance between two points in 2D space.</summary>
    public static double Distance2D(double x1, double y1, double x2, double y2)
        => Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

    /// <summary>Distance between two points in 3D space.</summary>
    public static double Distance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        => Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));

    /// <summary>Law of cosines: find side c given a, b and angle C in degrees.</summary>
    public static double LawOfCosines(double a, double b, double angleC)
        => Math.Sqrt(a * a + b * b - 2 * a * b * Cos(angleC));

    /// <summary>Law of sines ratio: a / sin(A). Returns the ratio.</summary>
    public static double LawOfSinesRatio(double side, double oppositeDegrees)
    {
        double s = Sin(oppositeDegrees);
        if (Math.Abs(s) < 1e-10)
            throw new ArgumentException("Angle produces an undefined sine value.");
        return side / s;
    }
}
