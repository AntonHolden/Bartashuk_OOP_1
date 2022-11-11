using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace Task1;

public class Phase1Test
{
    [Test]
    public void TestCanonicity()
    {
        Multiple(() =>
        {
            AssertRationalToString(2, 4, "1/2");
            AssertRationalToString(2, 4, "1/2");
            AssertRationalToString(2, 4, "1/2");
            AssertRationalToString(2, 4, "1/2");

            AssertRationalToString(4, 2, "2");
            AssertRationalToString(0, 10, "0");
            AssertRationalToString(100, 10, "10");
        });
    }

    private static void AssertRationalToString(int numerator, int denominator, string expected)
    {
        That(new Rational(numerator, denominator).ToString(), Is.EqualTo(expected));
    }
}