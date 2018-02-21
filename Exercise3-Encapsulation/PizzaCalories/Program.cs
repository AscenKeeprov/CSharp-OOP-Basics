using System;

class Program
{
    static void Main()
    {
	string pizzaName = Console.ReadLine().Split()[1];
	try
	{
	    Pizza pizza = new Pizza(pizzaName);
	    KneadDough(pizza);
	    Garnish(pizza);
	    Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
	}
	catch (ArgumentException exception)
	{
	    Console.WriteLine(exception.Message);
	}
    }

    static void KneadDough(Pizza pizza)
    {
	string[] doughInfo = Console.ReadLine().Split();
	string flourType = doughInfo[1];
	string bakingTechnique = doughInfo[2];
	double doughWeight = double.Parse(doughInfo[3]);
	pizza.KneadDough(new Dough(flourType, bakingTechnique, doughWeight));
    }

    static void Garnish(Pizza pizza)
    {
	string newTopping;
	while (!(newTopping = Console.ReadLine()).Equals("END"))
	{
	    string[] toppingInfo = newTopping.Split();
	    string toppingType = toppingInfo[1];
	    double toppingWeight = double.Parse(toppingInfo[2]);
	    pizza.AddTopping(new Topping(toppingType, toppingWeight));
	}
    }
}
