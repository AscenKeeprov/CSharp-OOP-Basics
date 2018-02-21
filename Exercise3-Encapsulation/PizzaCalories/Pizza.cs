using System;
using System.Collections.Generic;

public class Pizza
{
    private string name;
    private const int MinNameLength = 1;
    private const int MaxNameLength = 15;
    private const string InvalidName = "Pizza name should be between {0} and {1} symbols.";
    private Dough Dough { get; set; }
    private List<Topping> Toppings { get; set; }
    private const int MinNumberOfToppings = 0;
    private const int MaxNumberOfToppings = 10;
    private const string InvalidNumberOfToppings = "Number of toppings should be in range [{0}..{1}].";
    public double TotalCalories => CalculateCalories();

    public string Name
    {
	get { return name; }
	protected set
	{
	    if (String.IsNullOrEmpty(value) ||
		value.Length < MinNameLength || value.Length > MaxNameLength)
		throw new ArgumentException(String.Format(
		    InvalidName, MinNameLength, MaxNameLength));
	    name = value;
	}
    }

    public Pizza()
    {
	Toppings = new List<Topping>();
    }

    public Pizza(string name) : this()
    {
	Name = name;
    }

    public void KneadDough(Dough dough)
    {
	Dough = dough;
    }

    public void AddTopping(Topping topping)
    {
	if (Toppings.Count == MaxNumberOfToppings)
	    throw new ArgumentException(String.Format(
		InvalidNumberOfToppings, MinNumberOfToppings, MaxNumberOfToppings));
	Toppings.Add(topping);
    }

    private double CalculateCalories()
    {
	double toppingsCalories = 0;
	foreach (Topping topping in Toppings)
	{
	    toppingsCalories += topping.TotalCalories;
	}
	return Dough.TotalCalories + toppingsCalories;
    }
}
