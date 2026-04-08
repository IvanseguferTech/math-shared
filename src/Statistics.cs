namespace MathLibrary;

/// <summary>
/// Descriptive statistics over collections of numbers.
/// </summary>
public static class Statistics
{
    public static double Mean(IEnumerable<double> values)
    {
        var list = RequireNonEmpty(values);
        return list.Average();
    }

    public static double Median(IEnumerable<double> values)
    {
        var sorted = RequireNonEmpty(values).Order().ToList();
        int mid = sorted.Count / 2;
        return sorted.Count % 2 == 0
            ? (sorted[mid - 1] + sorted[mid]) / 2.0
            : sorted[mid];
    }

    public static IEnumerable<double> Mode(IEnumerable<double> values)
    {
        var list = RequireNonEmpty(values);
        var groups = list.GroupBy(v => v).Select(g => (Value: g.Key, Count: g.Count()));
        int maxCount = groups.Max(g => g.Count);
        return groups.Where(g => g.Count == maxCount).Select(g => g.Value).Order();
    }

    public static double Variance(IEnumerable<double> values, bool population = false)
    {
        var list = RequireNonEmpty(values);
        if (!population && list.Count < 2)
            throw new InvalidOperationException("Sample variance requires at least 2 values.");
        double mean = list.Average();
        double sumSq = list.Sum(v => Math.Pow(v - mean, 2));
        return sumSq / (population ? list.Count : list.Count - 1);
    }

    public static double StandardDeviation(IEnumerable<double> values, bool population = false)
        => Math.Sqrt(Variance(values, population));

    public static double Range(IEnumerable<double> values)
    {
        var list = RequireNonEmpty(values);
        return list.Max() - list.Min();
    }

    public static double Sum(IEnumerable<double> values) => RequireNonEmpty(values).Sum();

    public static double Min(IEnumerable<double> values) => RequireNonEmpty(values).Min();

    public static double Max(IEnumerable<double> values) => RequireNonEmpty(values).Max();

    /// <summary>Percentile using linear interpolation (0–100).</summary>
    public static double Percentile(IEnumerable<double> values, double percentile)
    {
        if (percentile < 0 || percentile > 100)
            throw new ArgumentOutOfRangeException(nameof(percentile), "Percentile must be between 0 and 100.");
        var sorted = RequireNonEmpty(values).Order().ToList();
        if (sorted.Count == 1) return sorted[0];
        double index = (percentile / 100) * (sorted.Count - 1);
        int lower = (int)Math.Floor(index);
        int upper = (int)Math.Ceiling(index);
        return sorted[lower] + (index - lower) * (sorted[upper] - sorted[lower]);
    }

    public static double Skewness(IEnumerable<double> values)
    {
        var list = RequireNonEmpty(values);
        if (list.Count < 3)
            throw new InvalidOperationException("Skewness requires at least 3 values.");
        double mean = list.Average();
        double std = StandardDeviation(list);
        if (std == 0) return 0;
        int n = list.Count;
        double sum = list.Sum(v => Math.Pow((v - mean) / std, 3));
        return (n / ((double)(n - 1) * (n - 2))) * sum;
    }

    public static double Kurtosis(IEnumerable<double> values)
    {
        var list = RequireNonEmpty(values);
        if (list.Count < 4)
            throw new InvalidOperationException("Kurtosis requires at least 4 values.");
        double mean = list.Average();
        double std = StandardDeviation(list, population: true);
        if (std == 0) return 0;
        return list.Average(v => Math.Pow((v - mean) / std, 4));
    }

    private static List<double> RequireNonEmpty(IEnumerable<double> values)
    {
        var list = values?.ToList() ?? throw new ArgumentNullException(nameof(values));
        if (list.Count == 0)
            throw new ArgumentException("Collection must not be empty.", nameof(values));
        return list;
    }
}
