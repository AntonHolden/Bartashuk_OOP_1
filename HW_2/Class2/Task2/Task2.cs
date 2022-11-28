namespace Task2
{
    abstract class Animal
    {
        internal abstract string Name { get; }
        internal abstract string VoiceVerb { get; }
        internal abstract string Voice { get; }
        internal void Talk()
        {
            Console.WriteLine($"{Name} {VoiceVerb} '{Voice}'");
        }
    }

    class Cat : Animal
    {
        internal override string Name => "Кошка";
        internal override string VoiceVerb => "мяучит";
        internal override string Voice => "мяу-мяу";
    }

    class Dog : Animal
    {
        internal override string Name => "Собака";
        internal override string VoiceVerb => "гавкает";
        internal override string Voice => "гав-гав-гав";
    }

    class Goose : Animal
    {
        internal override string Name => "Гусь";
        internal override string VoiceVerb => "гогочет";
        internal override string Voice => "га-га-га";
    }

    public class Task2
    {
        public static void Main(string[] args)
        {
            RunTest();
        }

        internal static void RunTest()
        {
            foreach (var animal in new List<Animal> { new Cat(), new Dog(), new Goose() })
            {
                animal.Talk();
            }
        }
    }
}