using NUnit.Framework;
using static NUnit.Framework.Assert;
using static Task1.Task1;

namespace Task1;

public class Tests
{
    
    private readonly TextWriter _standartOut = Console.Out;
    private StringWriter _stringWriter = new();

    [SetUp]
    public void Setup()
    {
        var stringWriter = new StringWriter();
        _stringWriter = stringWriter;
        Console.SetOut(_stringWriter);
    }

    [TearDown]
    public void TearDown()
    {
        Console.SetOut(_standartOut);
        _stringWriter.Close();
    }

    [Test]
    public void RunTestTest()
    {
        RunTest();
        AssertOut(
@"age: 21
age: 21
age: 22
age: 23
age: 24
System.ArgumentException: Property name is immutable
System.FormatException: For input string: ""?""
System.ArgumentException: Incorrect JSON property format: 'age = 10'
JSON value of 'age' has been set 4 time(s)
count: 0
JSON value of 'count' has been set 1 time(s)
Class 'JsonIntProperty' instance has been created 2 time(s)");
    }
    
    private void AssertOut(string expected)
    {
        That(_stringWriter.ToString().TrimEnd(Environment.NewLine.ToCharArray()), Is.EqualTo(expected));
    }

}