using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
	List<Person> people = new List<Person>();
	int peopleCount = int.Parse(Console.ReadLine());
	for (int p = 1; p <= peopleCount; p++)
	{
	    string[] personInfo = Console.ReadLine().Split();
	    string name = personInfo[0];
	    int age = int.Parse(personInfo[1]);
	    if (personInfo.Length == 4)
	    {
		string id = personInfo[2];
		string birthdate = personInfo[3];
		Person citizen = new Citizen(name, age, id, birthdate);
		people.Add(citizen);
	    }
	    else if (personInfo.Length == 3)
	    {
		string group = personInfo[2];
		Person rebel = new Rebel(name, age, group);
		people.Add(rebel);
	    }
	}
	string personName;
	while ((personName = Console.ReadLine()) != "End")
	{
	    if (people.Any(p => p.Name == personName))
	    {
		Person person = people.First(p => p.Name == personName);
		person.BuyFood();
	    }
	}
	Console.WriteLine(people.Select(p => p.Food).Sum());
    }
}
