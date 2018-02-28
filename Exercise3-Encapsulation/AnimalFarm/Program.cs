﻿using System;

class Program
{
    static void Main()
    {
	string name = Console.ReadLine();
	int age = int.Parse(Console.ReadLine());
	try
	{
	    Chicken chicken = new Chicken(name, age);
	    Console.WriteLine("Chicken {0} (age {1}) can produce {2} eggs per day.",
		chicken.Name, chicken.Age, chicken.LayPerDay);
	}
	catch (ArgumentOutOfRangeException)
	{
	    Environment.Exit(160);
	}
    }
}