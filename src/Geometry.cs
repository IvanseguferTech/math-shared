namespace MathLibrary;

/// <summary>
/// Geometric calculations for common 2D and 3D shapes.
/// </summary>
public static class Geometry
{
    // ── Círculo ──────────────────────────────────────────────────────────────

    public static double CircleArea(double radius)
    {
        ValidatePositive(radius, nameof(radius));
        return Math.PI * radius * radius;
    }

    public static double CircleCircumference(double radius)
    {
        ValidatePositive(radius, nameof(radius));
        return 2 * Math.PI * radius;
    }

    public static double CircleDiameter(double radius)
    {
        ValidatePositive(radius, nameof(radius));
        return 2 * radius;
    }

    public static double CircleRadiusFromArea(double area)
    {
        ValidatePositive(area, nameof(area));
        return Math.Sqrt(area / Math.PI);
    }

    public static double CircleRadiusFromCircumference(double circumference)
    {
        ValidatePositive(circumference, nameof(circumference));
        return circumference / (2 * Math.PI);
    }

    // ── Rectángulo ───────────────────────────────────────────────────────────

    public static double RectangleArea(double width, double height)
    {
        ValidatePositive(width, nameof(width));
        ValidatePositive(height, nameof(height));
        return width * height;
    }

    public static double RectanglePerimeter(double width, double height)
    {
        ValidatePositive(width, nameof(width));
        ValidatePositive(height, nameof(height));
        return 2 * (width + height);
    }

    public static double RectangleDiagonal(double width, double height)
    {
        ValidatePositive(width, nameof(width));
        ValidatePositive(height, nameof(height));
        return Math.Sqrt(width * width + height * height);
    }

    // ── Triángulo ────────────────────────────────────────────────────────────

    public static double TriangleArea(double baseLength, double height)
    {
        ValidatePositive(baseLength, nameof(baseLength));
        ValidatePositive(height, nameof(height));
        return 0.5 * baseLength * height;
    }

    public static double TriangleAreaHeron(double a, double b, double c)
    {
        ValidatePositive(a, nameof(a));
        ValidatePositive(b, nameof(b));
        ValidatePositive(c, nameof(c));
        if (a + b <= c || a + c <= b || b + c <= a)
            throw new ArgumentException("The three sides do not form a valid triangle.");
        double s = (a + b + c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    public static double TrianglePerimeter(double a, double b, double c)
    {
        ValidatePositive(a, nameof(a));
        ValidatePositive(b, nameof(b));
        ValidatePositive(c, nameof(c));
        return a + b + c;
    }

    public static double TriangleHypotenuse(double a, double b)
    {
        ValidatePositive(a, nameof(a));
        ValidatePositive(b, nameof(b));
        return Math.Sqrt(a * a + b * b);
    }

    // ── Trapecio ─────────────────────────────────────────────────────────────

    public static double TrapezoidArea(double base1, double base2, double height)
    {
        ValidatePositive(base1, nameof(base1));
        ValidatePositive(base2, nameof(base2));
        ValidatePositive(height, nameof(height));
        return 0.5 * (base1 + base2) * height;
    }

    // ── Elipse ───────────────────────────────────────────────────────────────

    public static double EllipseArea(double semiMajor, double semiMinor)
    {
        ValidatePositive(semiMajor, nameof(semiMajor));
        ValidatePositive(semiMinor, nameof(semiMinor));
        return Math.PI * semiMajor * semiMinor;
    }

    // ── Esfera ───────────────────────────────────────────────────────────────

    public static double SphereVolume(double radius)
    {
        ValidatePositive(radius, nameof(radius));
        return (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
    }

    public static double SphereSurfaceArea(double radius)
    {
        ValidatePositive(radius, nameof(radius));
        return 4 * Math.PI * radius * radius;
    }

    // ── Cilindro ─────────────────────────────────────────────────────────────

    public static double CylinderVolume(double radius, double height)
    {
        ValidatePositive(radius, nameof(radius));
        ValidatePositive(height, nameof(height));
        return Math.PI * radius * radius * height;
    }

    public static double CylinderLateralArea(double radius, double height)
    {
        ValidatePositive(radius, nameof(radius));
        ValidatePositive(height, nameof(height));
        return 2 * Math.PI * radius * height;
    }

    public static double CylinderTotalArea(double radius, double height)
    {
        ValidatePositive(radius, nameof(radius));
        ValidatePositive(height, nameof(height));
        return CylinderLateralArea(radius, height) + 2 * CircleArea(radius);
    }

    // ── Cono ─────────────────────────────────────────────────────────────────

    public static double ConeVolume(double radius, double height)
    {
        ValidatePositive(radius, nameof(radius));
        ValidatePositive(height, nameof(height));
        return (1.0 / 3.0) * Math.PI * radius * radius * height;
    }

    public static double ConeSlantHeight(double radius, double height)
    {
        ValidatePositive(radius, nameof(radius));
        ValidatePositive(height, nameof(height));
        return Math.Sqrt(radius * radius + height * height);
    }

    public static double ConeLateralArea(double radius, double height)
    {
        ValidatePositive(radius, nameof(radius));
        ValidatePositive(height, nameof(height));
        return Math.PI * radius * ConeSlantHeight(radius, height);
    }

    // ── Cubo / Caja ──────────────────────────────────────────────────────────

    public static double CubeVolume(double side)
    {
        ValidatePositive(side, nameof(side));
        return Math.Pow(side, 3);
    }

    public static double CubeSurfaceArea(double side)
    {
        ValidatePositive(side, nameof(side));
        return 6 * side * side;
    }

    public static double BoxVolume(double width, double height, double depth)
    {
        ValidatePositive(width, nameof(width));
        ValidatePositive(height, nameof(height));
        ValidatePositive(depth, nameof(depth));
        return width * height * depth;
    }

    // ── Helpers ──────────────────────────────────────────────────────────────

    private static void ValidatePositive(double value, string name)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(name, $"{name} must be greater than zero.");
    }
}
