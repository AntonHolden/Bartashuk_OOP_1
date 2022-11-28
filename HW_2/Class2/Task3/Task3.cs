namespace Task3
{
    abstract class Creature
    {
        private protected abstract string Message { get; }
        internal void PrintMessage() => Console.Write($"{Message}\n");
    }

    class Human : Creature
    {
        internal string Greeting() => "Привет, я человек!";

        private protected override string Message => Greeting();
    }

    class Dog : Creature
    {
        internal string Bark() => "Гав!";
        private protected override string Message => Bark();
    }

    class Alien : Creature
    {
        internal string Command() => "Ты меня не видишь";
        private protected override string Message => Command();
    }

    public class Task3
    {
        internal static void PrintMessageFrom(Creature creature) => creature.PrintMessage();

        static List<Dog> FindDogs(List<Creature> creatures) => (from creature in creatures
                                                                where creature is Dog
                                                                select creature as Dog).ToList();

        public static void Main(string[] args)
        {
            RunTest();
        }

        internal static void RunTest()
        {
            var creatures = new List<Creature> { new Alien(), new Dog(), new Human(), new Dog() };
            Console.Write("Все сообщения:\n");

            foreach (var creature in creatures)
            {
                PrintMessageFrom(creature);
            }

            Console.Write('\n');
            Console.Write("Сообщения только от собак:\n");
            foreach (var dog in FindDogs(creatures))
            {
                Console.Write($"{dog.Bark()}\n");
            }
        }
    }
}