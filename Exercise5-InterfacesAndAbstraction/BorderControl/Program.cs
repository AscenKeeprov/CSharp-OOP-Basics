using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
	List<IIdentifiable> individuals = new List<IIdentifiable>();
	string input;
	while ((input = Console.ReadLine()) != "End")
	{
	    string[] individualInfo = input.Split();
	    string name = individualInfo[0];
	    string id = individualInfo[1];
	    if (individualInfo.Length == 3)
	    {
		int age = int.Parse(individualInfo[1]);
		id = individualInfo[2];
		IIdentifiable citizen = new Citizen(name, age, id);
		individuals.Add(citizen);
	    }
	    else if (individualInfo.Length == 2)
	    {
		IIdentifiable robot = new Robot(name, id);
		individuals.Add(robot);
	    }
	}
	string fakeIdsTail = Console.ReadLine();
	foreach (IIdentifiable individual in individuals)
	{
	    if (individual.Id.EndsWith(fakeIdsTail))
		Console.WriteLine(individual.Id);
	}
    }
}
