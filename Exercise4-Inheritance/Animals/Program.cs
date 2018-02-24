using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
	List<Animal> animals = new List<Animal>();
	string animalType;
	while((animalType = Console.ReadLine()) != "Beast!")
	{
	    try
	    {
		string[] animalInfo = Console.ReadLine().Split();
		string name = animalInfo[0];
		int age = int.Parse(animalInfo[1]);
		string gender = String.Empty;
		if (animalInfo.Length == 3) gender = animalInfo[2];
		switch (animalType)
		{
		    case "Cat":
			Cat cat = new Cat(name, age, gender);
			animals.Add(cat);
			break;
		    case "Dog":
			Dog dog = new Dog(name, age, gender);
			animals.Add(dog);
			break;
		    case "Frog":
			Frog frog = new Frog(name, age, gender);
			animals.Add(frog);
			break;
		    case "Kitten":
			Kitten kitten = new Kitten(name, age);
			animals.Add(kitten);
			break;
		    case "Tomcat":
			Tomcat tomcat = new Tomcat(name, age);
			animals.Add(tomcat);
			break;
		    default:
			throw new ArgumentException("Invalid input!");
		}
	    }
	    catch (ArgumentException exception)
	    {
		Console.WriteLine(exception.Message);
	    }
	}
	foreach (Animal animal in animals)
	{
	    Console.WriteLine(animal);
	}
    }
}
