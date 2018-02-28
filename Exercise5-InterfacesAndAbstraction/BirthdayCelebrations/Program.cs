using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
	List<Animate> animates = new List<Animate>();
	List<Inanimate> inanimates = new List<Inanimate>();
	string input;
	while ((input = Console.ReadLine()) != "End")
	{
	    string[] individualInfo = input.Split();
	    string individualType = individualInfo[0];
	    string name = individualInfo[1];
	    switch (individualType.ToUpper())
	    {
		case "CITIZEN":
		    int age = int.Parse(individualInfo[2]);
		    string id = individualInfo[3];
		    string birthdate = individualInfo[4];
		    Animate citizen = new Citizen(name, age, id, birthdate);
		    animates.Add(citizen);
		    break;
		case "PET":
		    birthdate = individualInfo[2];
		    Animate pet = new Pet(name, birthdate);
		    animates.Add(pet);
		    break;
		case "ROBOT":
		    id = individualInfo[2];
		    Inanimate robot = new Robot(name, id);
		    inanimates.Add(robot);
		    break;
	    }
	}
	string wantedYear = Console.ReadLine();
	foreach (Animate individual in animates)
	{
	    if (individual.Birthdate.EndsWith(wantedYear))
		Console.WriteLine(individual.Birthdate);
	}
    }
}
