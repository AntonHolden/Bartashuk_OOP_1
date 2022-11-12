namespace Task1;

public class main
{
    public static int gcd(int a, int b)
    {
        while (a != 0) (a, b) = (b % a, a);

        return Math.Abs(b);
    }
    public static void Main(string[] args)
    {
        //string s = "-15";
        //string[] splitter =s.Split('/');
        //Console.WriteLine(splitter[1] ?? 1);
    }
}