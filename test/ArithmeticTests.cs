using MathLibrary;
using Xunit;

namespace MathLibrary.Test;

public class ArithmeticTests
{
    // ── Add ──────────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(-1, 1, 0)]
    [InlineData(-5, -3, -8)]
    [InlineData(0, 0, 0)]
    [InlineData(1.5, 2.5, 4.0)]
    public void Add_ReturnsCorrectSum(double a, double b, double expected)
        => Assert.Equal(expected, Arithmetic.Add(a, b));

    // ── Subtract ─────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(10, 4, 6)]
    [InlineData(0, 5, -5)]
    [InlineData(-3, -7, 4)]
    public void Subtract_ReturnsCorrectDifference(double a, double b, double expected)
        => Assert.Equal(expected, Arithmetic.Subtract(a, b));

    // ── Multiply ─────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(3, 4, 12)]
    [InlineData(-2, 5, -10)]
    [InlineData(0, 999, 0)]
    [InlineData(1.5, 2, 3.0)]
    public void Multiply_ReturnsCorrectProduct(double a, double b, double expected)
        => Assert.Equal(expected, Arithmetic.Multiply(a, b));

    // ── Divide ───────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(10, 2, 5)]
    [InlineData(7, 2, 3.5)]
    [InlineData(-9, 3, -3)]
    public void Divide_ReturnsCorrectQuotient(double a, double b, double expected)
        => Assert.Equal(expected, Arithmetic.Divide(a, b));

    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
        => Assert.Throws<DivideByZeroException>(() => Arithmetic.Divide(5, 0));

    // ── Modulo ───────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(10, 3, 1)]
    [InlineData(20, 5, 0)]
    [InlineData(7, 4, 3)]
    public void Modulo_ReturnsCorrectRemainder(double a, double b, double expected)
        => Assert.Equal(expected, Arithmetic.Modulo(a, b));

    [Fact]
    public void Modulo_ByZero_ThrowsDivideByZeroException()
        => Assert.Throws<DivideByZeroException>(() => Arithmetic.Modulo(10, 0));

    // ── Power ────────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(2, 10, 1024)]
    [InlineData(3, 3, 27)]
    [InlineData(5, 0, 1)]
    [InlineData(2, -1, 0.5)]
    public void Power_ReturnsCorrectResult(double b, double e, double expected)
        => Assert.Equal(expected, Arithmetic.Power(b, e), precision: 10);

    // ── SquareRoot ───────────────────────────────────────────────────────────

    [Theory]
    [InlineData(25, 5)]
    [InlineData(2, 1.41421356)]
    [InlineData(0, 0)]
    public void SquareRoot_ReturnsCorrectResult(double value, double expected)
        => Assert.Equal(expected, Arithmetic.SquareRoot(value), 5);

    [Fact]
    public void SquareRoot_Negative_ThrowsArgumentOutOfRange()
        => Assert.Throws<ArgumentOutOfRangeException>(() => Arithmetic.SquareRoot(-1));

    // ── AbsoluteValue ────────────────────────────────────────────────────────

    [Theory]
    [InlineData(-5, 5)]
    [InlineData(3, 3)]
    [InlineData(0, 0)]
    public void AbsoluteValue_ReturnsPositive(double value, double expected)
        => Assert.Equal(expected, Arithmetic.AbsoluteValue(value));

    // ── Factorial ────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(5, 120)]
    [InlineData(10, 3628800)]
    public void Factorial_ReturnsCorrectResult(int n, double expected)
        => Assert.Equal(expected, Arithmetic.Factorial(n));

    [Fact]
    public void Factorial_Negative_ThrowsArgumentOutOfRange()
        => Assert.Throws<ArgumentOutOfRangeException>(() => Arithmetic.Factorial(-1));

    // ── GCD ──────────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(48, 18, 6)]
    [InlineData(100, 75, 25)]
    [InlineData(7, 13, 1)]
    [InlineData(0, 5, 5)]
    public void GCD_ReturnsCorrectDivisor(long a, long b, long expected)
        => Assert.Equal(expected, Arithmetic.GreatestCommonDivisor(a, b));

    // ── LCM ──────────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(4, 6, 12)]
    [InlineData(3, 5, 15)]
    [InlineData(0, 8, 0)]
    public void LCM_ReturnsCorrectMultiple(long a, long b, long expected)
        => Assert.Equal(expected, Arithmetic.LeastCommonMultiple(a, b));

    // ── IsPrime ──────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(17, true)]
    [InlineData(97, true)]
    [InlineData(1, false)]
    [InlineData(4, false)]
    [InlineData(100, false)]
    [InlineData(-7, false)]
    public void IsPrime_ReturnsCorrectResult(int n, bool expected)
        => Assert.Equal(expected, Arithmetic.IsPrime(n));

    // ── Fibonacci ────────────────────────────────────────────────────────────

    [Fact]
    public void Fibonacci_ReturnsCorrectSequence()
    {
        var result = Arithmetic.Fibonacci(8).ToList();
        Assert.Equal(new[] { 0, 1, 1, 2, 3, 5, 8, 13 }, result);
    }

    [Fact]
    public void Fibonacci_CountZero_ThrowsArgumentOutOfRange()
        => Assert.Throws<ArgumentOutOfRangeException>(() => Arithmetic.Fibonacci(0).ToList());
}
