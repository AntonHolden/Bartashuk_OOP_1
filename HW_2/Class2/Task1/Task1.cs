using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Task1

{
    class JsonIntProperty
    {
        public static int InstanceCounter { get; private set; } = 0;
        private int? value;
        public int? Value {
            get => value;
            set
            {
                this.value = value;
                SetValueCounter++;
                StringRepresentation = $"{Name}: {Value}";
            }
        }
        private string? Name { get; init; }
        private string stringRepresentation;
        public string StringRepresentation
        {
            get => stringRepresentation;
            set
            {
                stringRepresentation = value;
                if (StringRepresentation != $"{Name}: {Value}")
                {
                    if (!Regex.IsMatch(StringRepresentation, @"\w*: \w*")) throw new ArgumentException($"Incorrect JSON property format: '{StringRepresentation}'");

                    StringBuilder stringBuilder = new StringBuilder();
                    int newValue;

                    foreach (var symb in StringRepresentation)
                    {
                        if (symb != ' ')
                        {
                            if (symb == ':')
                            {
                                if (stringBuilder.ToString() != Name) throw new ArgumentException("Property name is immutable");
                                stringBuilder.Clear();
                                continue;
                            }
                            stringBuilder.Append(symb);
                        }
                    }
                    if (!int.TryParse(stringBuilder.ToString(), out newValue)) throw new FormatException(@$"For input string: ""{stringBuilder}""");

                    Value = newValue;
                    StringRepresentation = $"{Name}: {Value}";
                }
            }
        }
        public int SetValueCounter { get; private set; } = 0;

        public JsonIntProperty(string name, int value=0)
        {
            Name = name;
            Value = value;
            StringRepresentation = $"{Name}: {Value}";
            InstanceCounter++;
        }

        public override string ToString() => StringRepresentation;
    }

    public class Task1
    {
        public static void Main(string[] args)
        {
            RunTest();
        }

        internal static void RunTest()
        {
            //throw new NotImplementedException("Раскомментируйте код ниже и реализуйте требуемую функциональность в классе JsonIntProperty");

            var ageProperty = new JsonIntProperty("age", 21);
            Console.Write($"{ageProperty}\n");
            Console.Write($"{ageProperty.StringRepresentation}\n");
            ageProperty.Value += 1;
            Console.Write($"{ageProperty}\n");
            ageProperty.StringRepresentation = "age: 23";
            Console.Write($"{ageProperty}\n");
            ageProperty.StringRepresentation = "age   :   24";
            Console.Write($"{ageProperty}\n");
            try
            {
                ageProperty.StringRepresentation = "value : 10";
            }
            catch (Exception e)
            {
                Console.Write($"{e.GetType()}: {e.Message}\n");
            }

            try
            {
                ageProperty.StringRepresentation = "age: ?";
            }
            catch (Exception e)
            {
                Console.Write($"{e.GetType()}: {e.Message}\n");
            }

            try
            {
                ageProperty.StringRepresentation = "age = 10";
            }
            catch (Exception e)
            {
                Console.Write($"{e.GetType()}: {e.Message}\n"); ;
            }

            Console.Write($"JSON value of 'age' has been set {ageProperty.SetValueCounter} time(s)\n");
            var countProperty = new JsonIntProperty("count");
            Console.Write($"{countProperty}\n");
            Console.Write($"JSON value of 'count' has been set {countProperty.SetValueCounter} time(s)\n");
            Console.Write(
                $"Class 'JsonIntProperty' instance has been created {JsonIntProperty.InstanceCounter} time(s)\n");
        }

    }
}