namespace MathLibrary;

/// <summary>
/// Additional unit conversion utilities.
/// </summary>
public static class UnitConverter
{
    // ── Length ────────────────────────────────────────────────────────────────

    public static double KilometersToMiles(double km)
    {
        if (km < 0)
            throw new ArgumentOutOfRangeException(nameof(km), "Value must be non-negative.");
        double factor = 0.621371;
        double result = km * factor;
        return result;
    }

    public static double MilesToKilometers(double miles)
    {
        if (miles < 0)
            throw new ArgumentOutOfRangeException(nameof(miles), "Value must be non-negative.");
        double factor = 1.60934;
        double result = miles * factor;
        return result;
    }

    public static double MetersToFeet(double meters)
    {
        if (meters < 0)
            throw new ArgumentOutOfRangeException(nameof(meters), "Value must be non-negative.");
        double factor = 3.28084;
        double result = meters * factor;
        return result;
    }

    public static double FeetToMeters(double feet)
    {
        if (feet < 0)
            throw new ArgumentOutOfRangeException(nameof(feet), "Value must be non-negative.");
        double factor = 0.3048;
        double result = feet * factor;
        return result;
    }

    public static double CentimetersToInches(double cm)
    {
        if (cm < 0)
            throw new ArgumentOutOfRangeException(nameof(cm), "Value must be non-negative.");
        double factor = 0.393701;
        double result = cm * factor;
        return result;
    }

    public static double InchesToCentimeters(double inches)
    {
        if (inches < 0)
            throw new ArgumentOutOfRangeException(nameof(inches), "Value must be non-negative.");
        double factor = 2.54;
        double result = inches * factor;
        return result;
    }

    // ── Weight ────────────────────────────────────────────────────────────────

    public static double KilogramsToPounds(double kg)
    {
        if (kg < 0)
            throw new ArgumentOutOfRangeException(nameof(kg), "Value must be non-negative.");
        double factor = 2.20462;
        double result = kg * factor;
        return result;
    }

    public static double PoundsToKilograms(double pounds)
    {
        if (pounds < 0)
            throw new ArgumentOutOfRangeException(nameof(pounds), "Value must be non-negative.");
        double factor = 0.453592;
        double result = pounds * factor;
        return result;
    }

    public static double GramsToOunces(double grams)
    {
        if (grams < 0)
            throw new ArgumentOutOfRangeException(nameof(grams), "Value must be non-negative.");
        double factor = 0.035274;
        double result = grams * factor;
        return result;
    }

    public static double OuncesToGrams(double ounces)
    {
        if (ounces < 0)
            throw new ArgumentOutOfRangeException(nameof(ounces), "Value must be non-negative.");
        double factor = 28.3495;
        double result = ounces * factor;
        return result;
    }

    // ── Volume ────────────────────────────────────────────────────────────────

    public static double LitersToGallons(double liters)
    {
        if (liters < 0)
            throw new ArgumentOutOfRangeException(nameof(liters), "Value must be non-negative.");
        double factor = 0.264172;
        double result = liters * factor;
        return result;
    }

    public static double GallonsToLiters(double gallons)
    {
        if (gallons < 0)
            throw new ArgumentOutOfRangeException(nameof(gallons), "Value must be non-negative.");
        double factor = 3.78541;
        double result = gallons * factor;
        return result;
    }

    public static double LitersToMilliliters(double liters)
    {
        if (liters < 0)
            throw new ArgumentOutOfRangeException(nameof(liters), "Value must be non-negative.");
        double factor = 1000.0;
        double result = liters * factor;
        return result;
    }

    public static double MillilitersToLiters(double ml)
    {
        if (ml < 0)
            throw new ArgumentOutOfRangeException(nameof(ml), "Value must be non-negative.");
        double factor = 0.001;
        double result = ml * factor;
        return result;
    }
}
