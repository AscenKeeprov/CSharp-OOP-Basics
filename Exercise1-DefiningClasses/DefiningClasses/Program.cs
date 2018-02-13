using System;
using System.Linq;

class Program
{
    static void Main()
    {
	Family family = new Family();
	int n = int.Parse(Console.ReadLine());
	for (int p = 1; p <= n; p++)
	{
	    string[] personInfo = Console.ReadLine().Split();
	    string name = personInfo[0];
	    if (personInfo.Length == 2)
	    {
		int age = int.Parse(personInfo[1]);
		Person person = new Person(name, age);
		family.AddMember(person);
	    }
	    else if (personInfo.Length == 1)
	    {
		if (int.TryParse(name, out int age))
		{
		    Person person = new Person(age);
		    family.AddMember(person);
		}
		else
		{
		    Person person = new Person(name);
		    family.AddMember(person);
		}
	    }
	}
	Person elder = family.GetOldestMember();
	Console.WriteLine($"{elder.Name} {elder.Age}");
    }
}
