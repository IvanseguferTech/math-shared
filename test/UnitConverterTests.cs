using MathLibrary;
using Xunit;

namespace MathLibrary.Test;

public class UnitConverterTests
{
    private const int Precision = 4;

    // ── Length ────────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0.621371)]
    [InlineData(100, 62.1371)]
    public void KilometersToMiles_ReturnsCorrectResult(double km, double expected)
        => Assert.Equal(expected, UnitConverter.KilometersToMiles(km), Precision);

    [Fact]
    public void KilometersToMiles_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => UnitConverter.KilometersToMiles(-1));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1.60934)]
    [InlineData(50, 80.467)]
    public void MilesToKilometers_ReturnsCorrectResult(double miles, double expected)
        => Assert.Equal(expected, UnitConverter.MilesToKilometers(miles), Precision);

    [Fact]
    public void MilesToKilometers_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => UnitConverter.MilesToKilometers(-5));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 3.28084)]
    [InlineData(10, 32.8084)]
    public void MetersToFeet_ReturnsCorrectResult(double meters, double expected)
        => Assert.Equal(expected, UnitConverter.MetersToFeet(meters), Precision);

    [Fact]
    public void MetersToFeet_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => UnitConverter.MetersToFeet(-1));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0.3048)]
    [InlineData(10, 3.048)]
    public void FeetToMeters_ReturnsCorrectResult(double feet, double expected)
        => Assert.Equal(expected, UnitConverter.FeetToMeters(feet), Precision);

    [Fact]
    public void FeetToMeters_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => UnitConverter.FeetToMeters(-3));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0.393701)]
    [InlineData(30, 11.8110)]
    public void CentimetersToInches_ReturnsCorrectResult(double cm, double expected)
        => Assert.Equal(expected, UnitConverter.CentimetersToInches(cm), Precision);

    [Fact]
    public void CentimetersToInches_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => UnitConverter.CentimetersToInches(-1));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 2.54)]
    [InlineData(12, 30.48)]
    public void InchesToCentimeters_ReturnsCorrectResult(double inches, double expected)
        => Assert.Equal(expected, UnitConverter.InchesToCentimeters(inches), Precision);

    [Fact]
    public void InchesToCentimeters_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => UnitConverter.InchesToCentimeters(-2));

    // ── Weight ────────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 2.20462)]
    [InlineData(70, 154.3234)]
    public void KilogramsToPounds_ReturnsCorrectResult(double kg, double expected)
        => Assert.Equal(expected, UnitConverter.KilogramsToPounds(kg), Precision);

    [Fact]
    public void KilogramsToPounds_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => UnitConverter.KilogramsToPounds(-1));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0.453592)]
    [InlineData(150, 68.0388)]
    public void PoundsToKilograms_ReturnsCorrectResult(double pounds, double expected)
        => Assert.Equal(expected, UnitConverter.PoundsToKilograms(pounds), Precision);

    [Fact]
    public void PoundsToKilograms_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => UnitConverter.PoundsToKilograms(-10));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(100, 3.5274)]
    [InlineData(1000, 35.274)]
    public void GramsToOunces_ReturnsCorrectResult(double grams, double expected)
        => Assert.Equal(expected, UnitConverter.GramsToOunces(grams), Precision);

    [Fact]
    public void GramsToOunces_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => UnitConverter.GramsToOunces(-1));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 28.3495)]
    [InlineData(16, 453.592)]
    public void OuncesToGrams_ReturnsCorrectResult(double ounces, double expected)
        => Assert.Equal(expected, UnitConverter.OuncesToGrams(ounces), Precision);

    [Fact]
    public void OuncesToGrams_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => UnitConverter.OuncesToGrams(-5));

    // ── Volume ────────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0.264172)]
    [InlineData(10, 2.64172)]
    public void LitersToGallons_ReturnsCorrectResult(double liters, double expected)
        => Assert.Equal(expected, UnitConverter.LitersToGallons(liters), Precision);

    [Fact]
    public void LitersToGallons_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => UnitConverter.LitersToGallons(-1));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 3.78541)]
    [InlineData(5, 18.9270)]
    public void GallonsToLiters_ReturnsCorrectResult(double gallons, double expected)
        => Assert.Equal(expected, UnitConverter.GallonsToLiters(gallons), Precision);

    [Fact]
    public void GallonsToLiters_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => UnitConverter.GallonsToLiters(-2));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1000)]
    [InlineData(2.5, 2500)]
    public void LitersToMilliliters_ReturnsCorrectResult(double liters, double expected)
        => Assert.Equal(expected, UnitConverter.LitersToMilliliters(liters), Precision);

    [Fact]
    public void LitersToMilliliters_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => UnitConverter.LitersToMilliliters(-1));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1000, 1)]
    [InlineData(500, 0.5)]
    public void MillilitersToLiters_ReturnsCorrectResult(double ml, double expected)
        => Assert.Equal(expected, UnitConverter.MillilitersToLiters(ml), Precision);

    [Fact]
    public void MillilitersToLiters_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => UnitConverter.MillilitersToLiters(-100));
}
