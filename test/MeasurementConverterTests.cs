using MathLibrary;
using Xunit;

namespace MathLibrary.Test;

public class MeasurementConverterTests
{
    private const int Precision = 4;

    // ── Length ────────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0.621371)]
    [InlineData(100, 62.1371)]
    public void KilometersToMiles_ReturnsCorrectResult(double km, double expected)
        => Assert.Equal(expected, MeasurementConverter.KilometersToMiles(km), Precision);

    [Fact]
    public void KilometersToMiles_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => MeasurementConverter.KilometersToMiles(-1));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1.60934)]
    [InlineData(50, 80.467)]
    public void MilesToKilometers_ReturnsCorrectResult(double miles, double expected)
        => Assert.Equal(expected, MeasurementConverter.MilesToKilometers(miles), Precision);

    [Fact]
    public void MilesToKilometers_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => MeasurementConverter.MilesToKilometers(-5));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 3.28084)]
    [InlineData(10, 32.8084)]
    public void MetersToFeet_ReturnsCorrectResult(double meters, double expected)
        => Assert.Equal(expected, MeasurementConverter.MetersToFeet(meters), Precision);

    [Fact]
    public void MetersToFeet_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => MeasurementConverter.MetersToFeet(-1));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0.3048)]
    [InlineData(10, 3.048)]
    public void FeetToMeters_ReturnsCorrectResult(double feet, double expected)
        => Assert.Equal(expected, MeasurementConverter.FeetToMeters(feet), Precision);

    [Fact]
    public void FeetToMeters_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => MeasurementConverter.FeetToMeters(-3));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0.393701)]
    [InlineData(30, 11.8110)]
    public void CentimetersToInches_ReturnsCorrectResult(double cm, double expected)
        => Assert.Equal(expected, MeasurementConverter.CentimetersToInches(cm), Precision);

    [Fact]
    public void CentimetersToInches_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => MeasurementConverter.CentimetersToInches(-1));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 2.54)]
    [InlineData(12, 30.48)]
    public void InchesToCentimeters_ReturnsCorrectResult(double inches, double expected)
        => Assert.Equal(expected, MeasurementConverter.InchesToCentimeters(inches), Precision);

    [Fact]
    public void InchesToCentimeters_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => MeasurementConverter.InchesToCentimeters(-2));

    // ── Weight ────────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 2.20462)]
    [InlineData(70, 154.3234)]
    public void KilogramsToPounds_ReturnsCorrectResult(double kg, double expected)
        => Assert.Equal(expected, MeasurementConverter.KilogramsToPounds(kg), Precision);

    [Fact]
    public void KilogramsToPounds_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => MeasurementConverter.KilogramsToPounds(-1));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0.453592)]
    [InlineData(150, 68.0388)]
    public void PoundsToKilograms_ReturnsCorrectResult(double pounds, double expected)
        => Assert.Equal(expected, MeasurementConverter.PoundsToKilograms(pounds), Precision);

    [Fact]
    public void PoundsToKilograms_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => MeasurementConverter.PoundsToKilograms(-10));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(100, 3.5274)]
    [InlineData(1000, 35.274)]
    public void GramsToOunces_ReturnsCorrectResult(double grams, double expected)
        => Assert.Equal(expected, MeasurementConverter.GramsToOunces(grams), Precision);

    [Fact]
    public void GramsToOunces_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => MeasurementConverter.GramsToOunces(-1));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 28.3495)]
    [InlineData(16, 453.592)]
    public void OuncesToGrams_ReturnsCorrectResult(double ounces, double expected)
        => Assert.Equal(expected, MeasurementConverter.OuncesToGrams(ounces), Precision);

    [Fact]
    public void OuncesToGrams_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => MeasurementConverter.OuncesToGrams(-5));

    // ── Temperature ───────────────────────────────────────────────────────────

    [Theory]
    [InlineData(0, 32)]
    [InlineData(100, 212)]
    [InlineData(-40, -40)]
    public void CelsiusToFahrenheit_ReturnsCorrectResult(double celsius, double expected)
        => Assert.Equal(expected, MeasurementConverter.CelsiusToFahrenheit(celsius), Precision);

    [Theory]
    [InlineData(32, 0)]
    [InlineData(212, 100)]
    [InlineData(-40, -40)]
    public void FahrenheitToCelsius_ReturnsCorrectResult(double fahrenheit, double expected)
        => Assert.Equal(expected, MeasurementConverter.FahrenheitToCelsius(fahrenheit), Precision);

    [Theory]
    [InlineData(0, 273.15)]
    [InlineData(100, 373.15)]
    [InlineData(-273.15, 0)]
    public void CelsiusToKelvin_ReturnsCorrectResult(double celsius, double expected)
        => Assert.Equal(expected, MeasurementConverter.CelsiusToKelvin(celsius), Precision);

    [Fact]
    public void CelsiusToKelvin_BelowAbsoluteZero_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => MeasurementConverter.CelsiusToKelvin(-274));

    [Theory]
    [InlineData(273.15, 0)]
    [InlineData(373.15, 100)]
    [InlineData(0, -273.15)]
    public void KelvinToCelsius_ReturnsCorrectResult(double kelvin, double expected)
        => Assert.Equal(expected, MeasurementConverter.KelvinToCelsius(kelvin), Precision);

    [Fact]
    public void KelvinToCelsius_Negative_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => MeasurementConverter.KelvinToCelsius(-1));
}
