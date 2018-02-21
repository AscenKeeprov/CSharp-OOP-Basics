using System;
using System.Collections.Generic;

public class Topping
{
    private string type;
    private const string InvalidToppingType = "Cannot place {0} on top of your pizza.";
    private double weight;
    private const double MinWeight = 1;
    private const double MaxWeight = 50;
    private const string InvalidToppingWeight = "{0} weight should be in the range [{1}..{2}].";
    private const double BaseCaloriesModifier = 2;
    public double TotalCalories => CalculateCalories();
    public double CaloriesPerGram => TotalCalories / Weight;

    private Dictionary<string, double> toppingTypes = new Dictionary<string, double>()
    {
	["CHEESE"] = 1.1,
	["MEAT"] = 1.2,
	["SAUCE"] = 0.9,
	["VEGGIES"] = 0.8
    };

    private string Type
    {
	get { return type; }
	set
	{
	    if (!toppingTypes.ContainsKey(value.ToUpper()))
		throw new ArgumentException(String.Format(InvalidToppingType, value));
	    type = value;
	}
    }

    private double Weight
    {
	get { return weight; }
	set
	{
	    if (value < MinWeight || value > MaxWeight)
		throw new ArgumentException(String.Format(
		    InvalidToppingWeight, Type, MinWeight, MaxWeight));
	    weight = value;
	}
    }

    public Topping(string type, double weight)
    {
	Type = type;
	Weight = weight;
    }

    private double CalculateCalories()
    {
	double toppingTypeModifier = toppingTypes[Type.ToUpper()];
	return Weight * BaseCaloriesModifier * toppingTypeModifier;
    }
}
