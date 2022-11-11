using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace Task1;

public class Phase2Test
{
    [Test]
    public void TestSecondaryConstructors()
    {
        var r = new Rational(-4, 3);
        Multiple(() =>
        {
            Fail("Раскомментируйте тесты ниже и реализуйте требуемую функциональность в классе Rational");
            /*                
            That(new Rational(-1, 1, 3), Is.EqualTo(r));
            That(new Rational(0, -4, 3), Is.EqualTo(r));
            That(new Rational(r), Is.EqualTo(r));
            That(new Rational("-4/3"), Is.EqualTo(r));
            That(new Rational("-12/9"), Is.EqualTo(r));
            */
        });
    }
}