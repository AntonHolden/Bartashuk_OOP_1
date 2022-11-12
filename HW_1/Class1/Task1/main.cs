using System.Text;
using static Task1.VulgarFractions;

namespace Task1;

public class main
{
    public static int gcd(int a, int b)
    {
        while (a != 0) (a, b) = (b % a, a);

        return Math.Abs(b);
    }

    public static void GenerateTable()
    {
        Console.WriteLine("Table:");
        Console.Write("n = ");
        int n;

        if ((int.TryParse(Console.ReadLine(), out n)) && (n > 1))
        {
            Console.WriteLine();
            int blank;
            StringBuilder table = new();

            void AddValue(Rational rationalN) => table.Append("  ").Append(rationalN.ToString().PadRight(blank));

            blank = (n * n).ToString().Length + ((n - 1) * (n - 1)).ToString().Length + 1;

            table.Append(String.Concat(Enumerable.Repeat(' ', blank)));

            for (int currentN = 1; currentN < n; currentN++) AddValue(new Rational(currentN, n));
            table.Append('\n').Append(String.Concat(Enumerable.Repeat('-', blank * n + (2 * n) - 1))).Append('\n');

            for (int i = 1; i < n; i++)
            {
                Rational rowRationalN = new(i, n);
                table.Append(rowRationalN.ToString().PadRight(blank));

                for (int j = 1; j < n; j++) AddValue((new Rational(j, n)) * rowRationalN);

                if (i < (n - 1)) table.Append('\n');
            }

            Console.WriteLine(table.ToString());
        }
    }



    public static void Main(string[] args)
    {
        GenerateTable();
        Console.WriteLine();
        GenerateTasks();
    }
}