using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
	Wizard Gandalf = new Wizard("Gandalf the Gray");
	Queue<string> foods = new Queue<string>(Console.ReadLine().Split());
	FoodFactory foodFactory = new FoodFactory();
	while (foods.Count > 0)
	{
	    string foodType = foods.Dequeue();
	    Food food = (Food)foodFactory.Produce(foodType);
	    Gandalf.Eat(food);
	}
	Console.WriteLine(Gandalf.MoodPoints);
	MoodFactory moodFactory = new MoodFactory();
	Mood mood = (Mood)moodFactory.Produce(Gandalf.MoodPoints);
	Console.WriteLine(mood.Type);
    }
}
