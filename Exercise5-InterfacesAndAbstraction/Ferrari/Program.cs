using System;

public class Program
{
    static void Main()
    {
	string driver = Console.ReadLine();
	Ferrari ferrari = new Ferrari(driver);
	Console.Write($"{ferrari.Model}");
	Console.Write("/");
	ferrari.PushBrakes();
	Console.Write("/");
	ferrari.PushGasPedal();
	Console.Write("/");
	Console.WriteLine(ferrari.Driver);
    }
}
