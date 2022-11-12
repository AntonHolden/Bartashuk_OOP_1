using static Task1.main;
namespace Task1;

public class Rational
{
    private int Numerator { get; }
    private int Denominator { get; }

    private int WholePart { get; }

    private bool IsZero { get; set; } = false;

    private bool IsWhole { get; set; } = false;

    private Rational ProperPart { get; }

    public Rational(int numerator, int denominator)
    {
        int g = gcd(numerator, denominator);
        numerator /= g * Math.Sign(denominator);
        denominator /= g * Math.Sign(denominator);

        Numerator = numerator;
        Denominator = denominator;

        //int wholePart = numerator / denominator;
        //if (wholePart < 0) wholePart--;
        //WholePart = wholePart;

        WholePart = numerator / denominator;
        if ((WholePart < 0) || ((WholePart == 0) && (numerator < 0))) WholePart--;

        if (WholePart != 0) ProperPart = new Rational(Numerator - (Denominator * WholePart), Denominator);
        else ProperPart = this;

        if (Denominator == 0) IsZero = true;
        if (Denominator == 1) IsWhole = true;
    }

    public Rational(int wholePart, int numerator, int denominator) :
        this((wholePart >= 0 ? 1 : -1) * (numerator + (Math.Abs(wholePart) * denominator)), denominator)
    { }

    public Rational(Rational rational) : this(rational.Numerator, rational.Denominator) { }

    public Rational(string s) : this(int.Parse(s.Split('/')[0]), (s.Split('/').Length > 1) ? int.Parse(s.Split('/')[1]) : 1) { }
    //{
    //    int numerator;
    //    int denominator = 1;

    //    string[] splitter = s.Split('/');

    //    if (!int.TryParse(splitter[0], out numerator)) throw new Exception("Ñan't identify the numerator in the passed string!");

    //    if ((splitter.Length > 1) && (!int.TryParse(splitter[1], out denominator)))
    //        throw new Exception("Ñan't identify the denominator in the passed string!");

    //    Init(numerator, denominator);
    //}

    public override string ToString()
    {
        if (IsZero) return "inf";
        if (IsWhole) return $"{WholePart}";
        if (WholePart == 0) return $"{ProperPart.Numerator}/{ProperPart.Denominator}";
        return $"{WholePart} {ProperPart.Numerator}/{ProperPart.Denominator}";
    }

    private bool Equals(Rational other) => GetHashCode() == other.GetHashCode();

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Rational)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }
}