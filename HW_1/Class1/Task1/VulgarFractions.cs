namespace Task1;

public class VulgarFractions
{
    static Dictionary<Rational, char> vulgarFractions = new()
    {
        { new Rational(1, 4), '\u00BC' },
        { new Rational(1, 2), '\u00BD' },
        { new Rational(3, 4), '\u00BE' },
        { new Rational(1, 7), '\u2150' },
        { new Rational(1, 9), '\u2151' },
        { new Rational(1, 10), '\u2152' },
        { new Rational(1, 3), '\u2153' },
        { new Rational(2, 3), '\u2154' },
        { new Rational(1, 5), '\u2155' },
        { new Rational(2, 5), '\u2156' },
        { new Rational(3, 5), '\u2157' },
        { new Rational(4, 5), '\u2158' },
        { new Rational(1, 6), '\u2159' },
        { new Rational(5, 6), '\u215A' },
        { new Rational(1, 8), '\u215B' },
        { new Rational(3, 8), '\u215C' },
        { new Rational(5, 8), '\u215D' },
        { new Rational(7, 8), '\u215E' },
    };

    private static string superscripts = "⁰¹²³⁴⁵⁶⁷⁸⁹";
    private static string subscripts = "₀₁₂₃₄₅₆₇₈₉";

    string ToMixedVulgarFraction(Rational r)
    {
        throw new NotImplementedException();
    }
}