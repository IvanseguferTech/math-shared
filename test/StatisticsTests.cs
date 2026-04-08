using MathLibrary;
using Xunit;

namespace MathLibrary.Test;

public class StatisticsTests
{
    private static readonly double[] Sample = { 2, 4, 4, 4, 5, 5, 7, 9 };

    // ── Mean ─────────────────────────────────────────────────────────────────

    [Fact]
    public void Mean_ReturnsCorrectAverage()
        => Assert.Equal(5.0, Statistics.Mean(Sample));

    [Fact]
    public void Mean_EmptyCollection_Throws()
        => Assert.Throws<ArgumentException>(() => Statistics.Mean([]));

    // ── Median ───────────────────────────────────────────────────────────────

    [Fact]
    public void Median_EvenCount_ReturnsAverageOfMiddleTwo()
        => Assert.Equal(4.5, Statistics.Median(Sample));

    [Fact]
    public void Median_OddCount_ReturnsMiddleValue()
        => Assert.Equal(3.0, Statistics.Median([1, 2, 3, 4, 5]));

    // ── Mode ─────────────────────────────────────────────────────────────────

    [Fact]
    public void Mode_ReturnsMostFrequentValue()
    {
        var modes = Statistics.Mode(Sample).ToList();
        Assert.Contains(4.0, modes);
    }

    [Fact]
    public void Mode_BiModal_ReturnsBothValues()
    {
        var modes = Statistics.Mode([1, 1, 2, 2, 3]).ToList();
        Assert.Equal(2, modes.Count);
        Assert.Contains(1.0, modes);
        Assert.Contains(2.0, modes);
    }

    // ── Variance ─────────────────────────────────────────────────────────────

    [Fact]
    public void Variance_Population_ReturnsCorrectResult()
        => Assert.Equal(4.0, Statistics.Variance(Sample, population: true), 5);

    [Fact]
    public void Variance_Sample_ReturnsCorrectResult()
        => Assert.Equal(4.571428, Statistics.Variance(Sample, population: false), 4);

    [Fact]
    public void Variance_SingleValue_SampleThrows()
        => Assert.Throws<InvalidOperationException>(() => Statistics.Variance([5.0]));

    // ── Standard Deviation ───────────────────────────────────────────────────

    [Fact]
    public void StandardDeviation_Population_ReturnsTwo()
        => Assert.Equal(2.0, Statistics.StandardDeviation(Sample, population: true), 5);

    // ── Range ────────────────────────────────────────────────────────────────

    [Fact]
    public void Range_ReturnsCorrectRange()
        => Assert.Equal(7.0, Statistics.Range(Sample));

    // ── Sum / Min / Max ──────────────────────────────────────────────────────

    [Fact]
    public void Sum_ReturnsCorrectTotal()
        => Assert.Equal(40.0, Statistics.Sum(Sample));

    [Fact]
    public void Min_ReturnsSmallestValue()
        => Assert.Equal(2.0, Statistics.Min(Sample));

    [Fact]
    public void Max_ReturnsLargestValue()
        => Assert.Equal(9.0, Statistics.Max(Sample));

    // ── Percentile ───────────────────────────────────────────────────────────

    [Fact]
    public void Percentile_0_ReturnsMin()
        => Assert.Equal(2.0, Statistics.Percentile(Sample, 0));

    [Fact]
    public void Percentile_100_ReturnsMax()
        => Assert.Equal(9.0, Statistics.Percentile(Sample, 100));

    [Fact]
    public void Percentile_50_ReturnsMedian()
        => Assert.Equal(Statistics.Median(Sample), Statistics.Percentile(Sample, 50), 5);

    [Fact]
    public void Percentile_OutOfRange_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => Statistics.Percentile(Sample, 101));

    // ── Skewness / Kurtosis ───────────────────────────────────────────────────

    [Fact]
    public void Skewness_PositiveSkew_ReturnsPositiveValue()
    {
        double skew = Statistics.Skewness([1, 2, 2, 3, 10]);
        Assert.True(skew > 0, $"Expected positive skewness but got {skew}");
    }

    [Fact]
    public void Kurtosis_NormalLike_ReturnsReasonableValue()
    {
        double k = Statistics.Kurtosis([2, 4, 4, 4, 5, 5, 7, 9]);
        Assert.True(k > 0);
    }
}
