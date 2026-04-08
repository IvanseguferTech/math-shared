using MathLibrary;
using Xunit;

namespace MathLibrary.Test;

public class AlgebraTests
{
    private const int Precision = 5;

    // ── Logaritmos ───────────────────────────────────────────────────────────

    [Fact]
    public void Log10_Of1000_Returns3()
        => Assert.Equal(3.0, Algebra.Log10(1000), Precision);

    [Fact]
    public void NaturalLog_OfE_Returns1()
        => Assert.Equal(1.0, Algebra.NaturalLog(Math.E), Precision);

    [Fact]
    public void Log_Base2_Of8_Returns3()
        => Assert.Equal(3.0, Algebra.Log(8, 2), Precision);

    [Fact]
    public void Log_NegativeInput_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => Algebra.Log(-1));

    [Fact]
    public void Log10_Zero_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => Algebra.Log10(0));

    // ── Cuadrática ───────────────────────────────────────────────────────────

    [Fact]
    public void QuadraticRoots_TwoDistinctRoots()
    {
        // x² - 5x + 6 = 0  →  x = 3, x = 2
        var (r1, r2) = Algebra.QuadraticRoots(1, -5, 6);
        Assert.Equal(3.0, r1, Precision);
        Assert.Equal(2.0, r2, Precision);
    }

    [Fact]
    public void QuadraticRoots_RepeatedRoot()
    {
        // x² - 4x + 4 = 0  →  x = 2
        var (r1, r2) = Algebra.QuadraticRoots(1, -4, 4);
        Assert.Equal(2.0, r1, Precision);
        Assert.Equal(2.0, r2, Precision);
    }

    [Fact]
    public void QuadraticRoots_NoRealSolution_Throws()
        => Assert.Throws<InvalidOperationException>(() => Algebra.QuadraticRoots(1, 0, 1));

    [Fact]
    public void QuadraticRoots_ZeroLeadCoefficient_Throws()
        => Assert.Throws<ArgumentException>(() => Algebra.QuadraticRoots(0, 1, 2));

    [Fact]
    public void QuadraticDiscriminant_ReturnsCorrectValue()
        => Assert.Equal(25.0, Algebra.QuadraticDiscriminant(1, -5, 0));

    // ── Progresión aritmética ─────────────────────────────────────────────────

    [Theory]
    [InlineData(1, 2, 5, 9)]   // 1, 3, 5, 7, 9
    [InlineData(10, -3, 4, 1)] // 10, 7, 4, 1
    public void ArithmeticTerm_ReturnsNthTerm(double first, double d, int n, double expected)
        => Assert.Equal(expected, Algebra.ArithmeticTerm(first, d, n));

    [Fact]
    public void ArithmeticSum_First10NaturalNumbers()
        => Assert.Equal(55.0, Algebra.ArithmeticSum(1, 1, 10));

    // ── Progresión geométrica ─────────────────────────────────────────────────

    [Fact]
    public void GeometricTerm_PowersOf2()
        => Assert.Equal(16.0, Algebra.GeometricTerm(1, 2, 5));

    [Fact]
    public void GeometricSum_DoublingSequence()
        => Assert.Equal(31.0, Algebra.GeometricSum(1, 2, 5));

    [Fact]
    public void GeometricSum_RatioOne_ReturnsFirstTimesN()
        => Assert.Equal(30.0, Algebra.GeometricSum(6, 1, 5));

    // ── Combinatoria ─────────────────────────────────────────────────────────

    [Theory]
    [InlineData(5, 2, 10)]
    [InlineData(10, 3, 120)]
    [InlineData(6, 0, 1)]
    [InlineData(6, 6, 1)]
    [InlineData(3, 5, 0)]
    public void Combinations_ReturnsCorrectResult(int n, int k, long expected)
        => Assert.Equal(expected, Algebra.Combinations(n, k));

    [Theory]
    [InlineData(5, 2, 20)]
    [InlineData(6, 3, 120)]
    [InlineData(4, 4, 24)]
    public void Permutations_ReturnsCorrectResult(int n, int k, long expected)
        => Assert.Equal(expected, Algebra.Permutations(n, k));

    // ── Polinomio ────────────────────────────────────────────────────────────

    [Fact]
    public void EvaluatePolynomial_QuadraticAt2()
    {
        // 2x² - 3x + 1  at x=2 → 8 - 6 + 1 = 3
        double result = Algebra.EvaluatePolynomial(2, [2, -3, 1]);
        Assert.Equal(3.0, result);
    }

    [Fact]
    public void EvaluatePolynomial_ConstantPolynomial()
        => Assert.Equal(7.0, Algebra.EvaluatePolynomial(99, [7]));

    [Fact]
    public void EvaluatePolynomial_EmptyCoefficients_Throws()
        => Assert.Throws<ArgumentException>(() => Algebra.EvaluatePolynomial(1, []));

    // ── Interés ───────────────────────────────────────────────────────────────

    [Fact]
    public void SimpleInterest_ReturnsCorrectAmount()
        => Assert.Equal(150.0, Algebra.SimpleInterest(1000, 0.05, 3));

    [Fact]
    public void CompoundInterest_AnnualCompounding()
    {
        // 1000 at 5% annually for 2 years = 1102.5
        double result = Algebra.CompoundInterest(1000, 0.05, 2, 1);
        Assert.Equal(1102.5, result, Precision);
    }

    [Fact]
    public void CompoundInterest_MonthlyCompounding_GreaterThanAnnual()
    {
        double annual = Algebra.CompoundInterest(1000, 0.12, 1, 1);
        double monthly = Algebra.CompoundInterest(1000, 0.12, 1, 12);
        Assert.True(monthly > annual);
    }

    [Fact]
    public void SimpleInterest_NegativeRate_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => Algebra.SimpleInterest(1000, -0.1, 1));
}
