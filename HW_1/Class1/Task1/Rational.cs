using System;
using System.Text;
using static Task1.main;
namespace Task1;


public class Rational
{
    public int Numerator { get; }
    public int Denominator { get; }
    public int WholePart { get; }
    public bool IsZero { get; private set; } = false;
    public bool IsWhole { get; private set; } = false;
    public Rational ProperPart { get; }

    public Rational(int numerator, int denominator)
    {
        int g = gcd(numerator, denominator);
        numerator /= g * Math.Sign(denominator);
        denominator /= g * Math.Sign(denominator);

        Numerator = numerator;
        Denominator = denominator;
        WholePart = numerator / denominator;

        if (WholePart != 0) ProperPart = new Rational(Math.Abs(Numerator) - (Denominator * Math.Abs(WholePart)), Denominator);
        else ProperPart = this;

        if (Denominator == 0) IsZero = true;
        if (Denominator == 1) IsWhole = true;
    }

    public Rational(int wholePart, int numerator, int denominator) :
        this((wholePart >= 0 ? 1 : -1) * (numerator + (Math.Abs(wholePart) * denominator)), denominator)
    { }

    public Rational(Rational rational) : this(rational.Numerator, rational.Denominator) { }

    public Rational(string s)
    {
        int wholePart = 0;
        int numerator;
        int denominator = 1;

        string[] splitter = s.Split(' ');
        if (splitter.Length < 2) splitter = s.Split('/');
        else
        {
            if (!int.TryParse(splitter[0], out wholePart)) throw new Exception("Can't parse the wholePart in the passed string!");
            splitter = splitter[1].Split('/');
        }

        if (!int.TryParse(splitter[0], out numerator)) throw new Exception("Can't parse the numerator in the passed string!");
        if ((splitter.Length > 1) && (!int.TryParse(splitter[1], out denominator)))
            throw new Exception("Can't parse the denominator in the passed string!");

        int g = gcd(numerator, denominator);
        numerator /= g * Math.Sign(denominator);
        denominator /= g * Math.Sign(denominator);

        Numerator = (wholePart >= 0 ? 1 : -1) * (numerator + (Math.Abs(wholePart) * denominator));
        Denominator = denominator;
        WholePart = numerator / denominator;

        if (WholePart != 0) ProperPart = new Rational(Math.Abs(Numerator) - (Denominator * Math.Abs(WholePart)), Denominator);
        else ProperPart = this;

        if (Denominator == 0) IsZero = true;
        else if (Denominator == 1) IsWhole = true;
    }

    public override string ToString()
    {
        if (IsZero) return "inf";
        if (IsWhole) return $"{WholePart}";

        StringBuilder output = new();
        if (ProperPart.Numerator < 0) output.Append('-');
        if (WholePart == 0) return output.Append($"{Math.Abs(ProperPart.Numerator)}/{ProperPart.Denominator}").ToString();

        return $"{WholePart} {ProperPart.Numerator}/{ProperPart.Denominator}";
    }

    public static implicit operator Rational(int i) => new(i, 1);

    public static Rational operator +(Rational a) => a;
    public static Rational operator -(Rational a) => new Rational(-a.Numerator, a.Denominator);

    public static Rational operator +(Rational a, Rational b)
    => new Rational((a.Numerator * b.Denominator) + (b.Numerator * a.Denominator), a.Denominator * b.Denominator);
    public static Rational operator -(Rational a, Rational b) => a + (-b);

    public static Rational operator *(Rational a, Rational b)
    => new Rational(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
    public static Rational operator /(Rational a, Rational b) => a * new Rational(b.Denominator, b.Numerator);

    public static bool operator >(Rational a, Rational b)
    => (a.Numerator * b.Denominator) > (b.Numerator * a.Denominator);
    public static bool operator <(Rational a, Rational b)
    => (a.Numerator * b.Denominator) < (b.Numerator * a.Denominator);

    public static bool operator >=(Rational a, Rational b)
    => (a.Numerator * b.Denominator) >= (b.Numerator * a.Denominator);
    public static bool operator <=(Rational a, Rational b)
    => (a.Numerator * b.Denominator) <= (b.Numerator * a.Denominator);

    public static bool operator !=(Rational a, Rational b)
    => (a.Numerator * b.Denominator) != (b.Numerator * a.Denominator);
    public static bool operator ==(Rational a, Rational b)
    => (a.Numerator * b.Denominator) == (b.Numerator * a.Denominator);

    private bool Equals(Rational other) => GetHashCode() == other.GetHashCode();

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Rational)obj);
    }

    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);
}