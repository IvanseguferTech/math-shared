using MathLibrary;
using Xunit;

namespace MathLibrary.Test;

public class GeometryTests
{
    private const double Tolerance = 1e-6;

    // ── Círculo ──────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(1, Math.PI)]
    [InlineData(5, 78.53981633)]
    public void CircleArea_ReturnsCorrectArea(double radius, double expected)
        => Assert.Equal(expected, Geometry.CircleArea(radius), 5);

    [Theory]
    [InlineData(1, 6.28318530)]
    [InlineData(7, 43.9822971)]
    public void CircleCircumference_ReturnsCorrectResult(double radius, double expected)
        => Assert.Equal(expected, Geometry.CircleCircumference(radius), 5);

    [Theory]
    [InlineData(3, 6)]
    [InlineData(0.5, 1)]
    public void CircleDiameter_ReturnsCorrectResult(double radius, double expected)
        => Assert.Equal(expected, Geometry.CircleDiameter(radius), 10);

    [Fact]
    public void CircleRadiusFromArea_ReturnsCorrectRadius()
    {
        double area = Math.PI * 4 * 4;
        Assert.Equal(4.0, Geometry.CircleRadiusFromArea(area), 5);
    }

    [Fact]
    public void CircleRadiusFromCircumference_ReturnsCorrectRadius()
    {
        double c = 2 * Math.PI * 6;
        Assert.Equal(6.0, Geometry.CircleRadiusFromCircumference(c), 5);
    }

    [Fact]
    public void CircleArea_NegativeRadius_ThrowsArgumentOutOfRange()
        => Assert.Throws<ArgumentOutOfRangeException>(() => Geometry.CircleArea(-1));

    // ── Rectángulo ───────────────────────────────────────────────────────────

    [Theory]
    [InlineData(4, 5, 20)]
    [InlineData(10, 10, 100)]
    public void RectangleArea_ReturnsCorrectArea(double w, double h, double expected)
        => Assert.Equal(expected, Geometry.RectangleArea(w, h));

    [Theory]
    [InlineData(3, 4, 14)]
    [InlineData(6, 6, 24)]
    public void RectanglePerimeter_ReturnsCorrectPerimeter(double w, double h, double expected)
        => Assert.Equal(expected, Geometry.RectanglePerimeter(w, h));

    [Fact]
    public void RectangleDiagonal_ReturnsCorrectDiagonal()
        => Assert.Equal(5.0, Geometry.RectangleDiagonal(3, 4), 10);

    // ── Triángulo ────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(10, 5, 25)]
    [InlineData(6, 4, 12)]
    public void TriangleArea_ReturnsCorrectArea(double b, double h, double expected)
        => Assert.Equal(expected, Geometry.TriangleArea(b, h));

    [Fact]
    public void TriangleAreaHeron_ReturnsCorrectArea()
        => Assert.Equal(6.0, Geometry.TriangleAreaHeron(3, 4, 5), 5);

    [Fact]
    public void TriangleAreaHeron_InvalidSides_ThrowsArgumentException()
        => Assert.Throws<ArgumentException>(() => Geometry.TriangleAreaHeron(1, 2, 10));

    [Fact]
    public void TriangleHypotenuse_ReturnsFive()
        => Assert.Equal(5.0, Geometry.TriangleHypotenuse(3, 4), 10);

    // ── Trapecio ─────────────────────────────────────────────────────────────

    [Fact]
    public void TrapezoidArea_ReturnsCorrectArea()
        => Assert.Equal(30.0, Geometry.TrapezoidArea(4, 8, 5));

    // ── Elipse ───────────────────────────────────────────────────────────────

    [Fact]
    public void EllipseArea_ReturnsCorrectArea()
        => Assert.Equal(Math.PI * 3 * 5, Geometry.EllipseArea(3, 5), 5);

    // ── Esfera ───────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(3, 113.09733)]
    [InlineData(1, 4.18879)]
    public void SphereVolume_ReturnsCorrectVolume(double r, double expected)
        => Assert.Equal(expected, Geometry.SphereVolume(r), 4);

    [Fact]
    public void SphereSurfaceArea_ReturnsCorrectArea()
        => Assert.Equal(4 * Math.PI, Geometry.SphereSurfaceArea(1), 5);

    // ── Cilindro ─────────────────────────────────────────────────────────────

    [Fact]
    public void CylinderVolume_ReturnsCorrectVolume()
    {
        double expected = Math.PI * 4 * 10;
        Assert.Equal(expected, Geometry.CylinderVolume(2, 10), 5);
    }

    [Fact]
    public void CylinderTotalArea_ReturnsCorrectArea()
    {
        double expected = 2 * Math.PI * 2 * 10 + 2 * Math.PI * 4;
        Assert.Equal(expected, Geometry.CylinderTotalArea(2, 10), 5);
    }

    // ── Cono ─────────────────────────────────────────────────────────────────

    [Fact]
    public void ConeVolume_ReturnsCorrectVolume()
    {
        double expected = (1.0 / 3) * Math.PI * 9 * 6;
        Assert.Equal(expected, Geometry.ConeVolume(3, 6), 5);
    }

    [Fact]
    public void ConeSlantHeight_ReturnsCorrectHeight()
        => Assert.Equal(5.0, Geometry.ConeSlantHeight(3, 4), 10);

    // ── Cubo ─────────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(3, 27)]
    [InlineData(5, 125)]
    public void CubeVolume_ReturnsCorrectVolume(double side, double expected)
        => Assert.Equal(expected, Geometry.CubeVolume(side));

    [Fact]
    public void CubeSurfaceArea_ReturnsCorrectArea()
        => Assert.Equal(54.0, Geometry.CubeSurfaceArea(3));

    [Fact]
    public void BoxVolume_ReturnsCorrectVolume()
        => Assert.Equal(60.0, Geometry.BoxVolume(3, 4, 5));
}
