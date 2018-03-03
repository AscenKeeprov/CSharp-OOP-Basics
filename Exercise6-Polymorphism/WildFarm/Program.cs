using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
	List<Animal> animals = new List<Animal>();
	string animalInput;
	while ((animalInput = Console.ReadLine()) != "End")
	{
	    try
	    {
		Animal animal = TameAnimal(animalInput, animals);
		animal.ProduceSound();
		Food food = PrepareFood();
		animal.Eat(food);
	    }
	    catch (Exception exception)
	    {
		if (exception is ArgumentException)
		    Console.WriteLine(exception.Message);
	    }
	}
	foreach (Animal animal in animals)
	{
	    Console.WriteLine(animal);
	}
    }

    private static Animal TameAnimal(string animalInput, List<Animal> animals)
    {
	string[] animalInfo = animalInput.Trim().Split();
	AnimalFactory animalFactory = new AnimalFactory();
	Animal animal = animalFactory.Produce(animalInfo);
	animals.Add(animal);
	return animal;
    }

    private static Food PrepareFood()
    {
	string foodInfo = Console.ReadLine();
	string foodType = foodInfo.Split()[0];
	int foodQuantity = int.Parse(foodInfo.Split()[1]);
	FoodFactory foodFactory = new FoodFactory();
	Food food = foodFactory.Produce(foodType, foodQuantity);
	return food;
    }
}
