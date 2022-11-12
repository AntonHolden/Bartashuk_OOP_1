using System.Text;

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

    public static string ToMixedVulgarFraction(Rational r)
    {
        StringBuilder vulgarFraction = new();

        if ((r.IsWhole) || (r.IsZero)) return r.ToString();
        if (r.WholePart != 0) vulgarFraction.Append(r.WholePart.ToString());

        if (vulgarFractions.ContainsKey(r.ProperPart)) return vulgarFraction.Append(vulgarFractions[r.ProperPart]).ToString();

        if (r.ProperPart.Numerator < 0) vulgarFraction.Append('-');
        foreach (char symb in Math.Abs(r.ProperPart.Numerator).ToString()) vulgarFraction.Append(superscripts[int.Parse(symb.ToString())]);
        vulgarFraction.Append('/');
        foreach (char symb in r.ProperPart.Denominator.ToString()) vulgarFraction.Append(subscripts[int.Parse(symb.ToString())]);

        return vulgarFraction.ToString();
    }

    public static void GenerateTasks()
    {
        Console.WriteLine("Tasks:");
        Console.Write("Number of tasks = ");
        int n;

        if (int.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine();
            Console.OutputEncoding = Encoding.UTF8;
            Random randomizer = new();

            for (int i = 0; i < n; i++)
            {
                StringBuilder output = new();

                List<Rational> fractions = new()
                {
                    new Rational(randomizer.Next(-40, 41), randomizer.Next(1, 41)),
                    new Rational(randomizer.Next(41), randomizer.Next(1, 41))
                };

                fractions.Add(fractions[0] + fractions[1]);

                int questionMarkInd = randomizer.Next(3);

                if (questionMarkInd == 0)
                {
                    output.Append($"? + {ToMixedVulgarFraction(fractions[1])} = {ToMixedVulgarFraction(fractions[2])} ");
                    output.Append(String.Concat(Enumerable.Repeat('-', 30 - output.Length)));
                    output.Append($" Answer: {ToMixedVulgarFraction(fractions[0])}");
                    Console.WriteLine(output.ToString());
                }
                else if (questionMarkInd == 1)
                {
                    output.Append($"{ToMixedVulgarFraction(fractions[0])} + ? = {ToMixedVulgarFraction(fractions[2])} ");
                    output.Append(String.Concat(Enumerable.Repeat('-', 30 - output.Length)));
                    output.Append($" Answer: {ToMixedVulgarFraction(fractions[1])}");
                    Console.WriteLine(output.ToString());
                }
                else
                {
                    output.Append($"{ToMixedVulgarFraction(fractions[0])} + {ToMixedVulgarFraction(fractions[1])} = ? ");
                    output.Append(String.Concat(Enumerable.Repeat('-', 30 - output.Length)));
                    output.Append($" Answer: {ToMixedVulgarFraction(fractions[2])}");
                    Console.WriteLine(output.ToString());
                }

                if (i < n - 1) Console.WriteLine();
            }
        }
    }
}