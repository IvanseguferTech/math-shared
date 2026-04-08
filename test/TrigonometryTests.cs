using MathLibrary;
using Xunit;

namespace MathLibrary.Test;

public class TrigonometryTests
{
    private const int Precision = 5;

    // ── Conversiones ─────────────────────────────────────────────────────────

    [Theory]
    [InlineData(0, 0)]
    [InlineData(90, Math.PI / 2)]
    [InlineData(180, Math.PI)]
    [InlineData(360, 2 * Math.PI)]
    public void DegreesToRadians_ReturnsCorrectResult(double deg, double expected)
        => Assert.Equal(expected, Trigonometry.DegreesToRadians(deg), Precision);

    [Theory]
    [InlineData(0, 0)]
    [InlineData(Math.PI / 2, 90)]
    [InlineData(Math.PI, 180)]
    public void RadiansToDegrees_ReturnsCorrectResult(double rad, double expected)
        => Assert.Equal(expected, Trigonometry.RadiansToDegrees(rad), Precision);

    // ── Sin ──────────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(0, 0)]
    [InlineData(30, 0.5)]
    [InlineData(90, 1)]
    [InlineData(180, 0)]
    public void Sin_ReturnsCorrectValue(double deg, double expected)
        => Assert.Equal(expected, Trigonometry.Sin(deg), Precision);

    // ── Cos ──────────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(0, 1)]
    [InlineData(60, 0.5)]
    [InlineData(90, 0)]
    public void Cos_ReturnsCorrectValue(double deg, double expected)
        => Assert.Equal(expected, Trigonometry.Cos(deg), Precision);

    // ── Tan ──────────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(0, 0)]
    [InlineData(45, 1)]
    public void Tan_ReturnsCorrectValue(double deg, double expected)
        => Assert.Equal(expected, Trigonometry.Tan(deg), Precision);

    [Fact]
    public void Tan_At90_ThrowsInvalidOperation()
        => Assert.Throws<InvalidOperationException>(() => Trigonometry.Tan(90));

    // ── Inverse ──────────────────────────────────────────────────────────────

    [Fact]
    public void ArcSin_ReturnsCorrectDegrees()
        => Assert.Equal(30.0, Trigonometry.ArcSin(0.5), Precision);

    [Fact]
    public void ArcSin_OutOfRange_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => Trigonometry.ArcSin(2));

    [Fact]
    public void ArcCos_ReturnsCorrectDegrees()
        => Assert.Equal(60.0, Trigonometry.ArcCos(0.5), Precision);

    [Fact]
    public void ArcTan_ReturnsCorrectDegrees()
        => Assert.Equal(45.0, Trigonometry.ArcTan(1), Precision);

    [Fact]
    public void ArcTan2_ReturnsCorrectAngle()
        => Assert.Equal(45.0, Trigonometry.ArcTan2(1, 1), Precision);

    // ── Recíprocas ───────────────────────────────────────────────────────────

    [Fact]
    public void Csc_At30_Returns2()
        => Assert.Equal(2.0, Trigonometry.Csc(30), Precision);

    [Fact]
    public void Sec_At60_Returns2()
        => Assert.Equal(2.0, Trigonometry.Sec(60), Precision);

    [Fact]
    public void Cot_At45_Returns1()
        => Assert.Equal(1.0, Trigonometry.Cot(45), Precision);

    // ── Hiperbólicas ─────────────────────────────────────────────────────────

    [Fact]
    public void Sinh_At0_Returns0()
        => Assert.Equal(0.0, Trigonometry.Sinh(0), Precision);

    [Fact]
    public void Cosh_At0_Returns1()
        => Assert.Equal(1.0, Trigonometry.Cosh(0), Precision);

    [Fact]
    public void Tanh_At0_Returns0()
        => Assert.Equal(0.0, Trigonometry.Tanh(0), Precision);

    // ── Distancias ───────────────────────────────────────────────────────────

    [Fact]
    public void Distance2D_ClassicTriangle_Returns5()
        => Assert.Equal(5.0, Trigonometry.Distance2D(0, 0, 3, 4), Precision);

    [Fact]
    public void Distance3D_ReturnsCorrectDistance()
        => Assert.Equal(Math.Sqrt(3), Trigonometry.Distance3D(0, 0, 0, 1, 1, 1), Precision);

    // ── Ley de cosenos ───────────────────────────────────────────────────────

    [Fact]
    public void LawOfCosines_RightAngle_ReturnsHypotenuse()
        => Assert.Equal(5.0, Trigonometry.LawOfCosines(3, 4, 90), Precision);
}
