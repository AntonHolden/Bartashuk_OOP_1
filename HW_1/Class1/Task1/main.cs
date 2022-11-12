using System.Text;
using static Task1.Rational;

namespace Task1;

public class main
{
    public static int gcd(int a, int b)
    {
        while (a != 0) (a, b) = (b % a, a);

        return Math.Abs(b);
    }

    internal record Table
    {
        private int blank;
        private StringBuilder table = new StringBuilder();

        public Table(int n)
        {
            if (n > 1)
            {
                blank = (n * n).ToString().Length + ((n - 1) * (n - 1)).ToString().Length + 1;

                table.Append(String.Concat(Enumerable.Repeat(' ', blank)));

                for (int currentN = 1; currentN < n; currentN++) AddValue(new Rational(currentN, n));
                table.Append('\n').Append(String.Concat(Enumerable.Repeat('-', blank * n + (2 * n) - 1))).Append('\n');

                for (int i = 1; i < n; i++)
                {
                    Rational rowRationalN = new Rational(i, n);
                    table.Append(rowRationalN.ToString().PadRight(blank));

                    for (int j = 1; j < n; j++) AddValue((new Rational(j, n)) * rowRationalN);

                    //table.Append('\n').Append(String.Concat(Enumerable.Repeat('-', blank * n + (2 * n) - 1)));
                    if (i < (n - 1)) table.Append('\n');
                }
            }
        }

        private void AddValue(Rational rationalN) => table.Append("  ").Append(rationalN.ToString().PadRight(blank));

        public override string ToString() => table.ToString();
    }
    public static void Main(string[] args)
    {
        int n;

        if (int.TryParse(Console.ReadLine(), out n)) Console.WriteLine(new Table(n).ToString());
    }
}