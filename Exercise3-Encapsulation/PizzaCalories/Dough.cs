using System;
using System.Collections.Generic;

public class Dough
{
    private string flourType;
    private const string InvalidFlourType = "Invalid type of dough.";
    private string bakingTechnique;
    private const string InvalidBakingTechnique = "Invalid type of dough.";
    private double weight;
    private const double MinWeight = 1;
    private const double MaxWeight = 200;
    private const string InvalidDoughWeight = "Dough weight should be in the range [{0}..{1}].";
    private const double BaseCaloriesModifier = 2;
    public double TotalCalories => CalculateCalories();
    public double CaloriesPerGram => TotalCalories / Weight;

    private Dictionary<string, double> flourTypes = new Dictionary<string, double>()
    {
	["WHITE"] = 1.5,
	["WHOLEGRAIN"] = 1.0
    };

    private string FlourType
    {
	get { return flourType; }
	set
	{
	    if (!flourTypes.ContainsKey(value.ToUpper()))
		throw new ArgumentException(InvalidFlourType);
	    flourType = value;
	}
    }

    private Dictionary<string, double> bakingTechniques = new Dictionary<string, double>()
    {
	["CHEWY"] = 1.1,
	["CRISPY"] = 0.9,
	["HOMEMADE"] = 1.0
    };

    private string BakingTechnique
    {
	get { return bakingTechnique; }
	set
	{
	    if (!bakingTechniques.ContainsKey(value.ToUpper()))
		throw new ArgumentException(InvalidBakingTechnique);
	    bakingTechnique = value;
	}
    }

    private double Weight
    {
	get { return weight; }
	set
	{
	    if (value < MinWeight || value > MaxWeight)
		throw new ArgumentException(String.Format(
		    InvalidDoughWeight, MinWeight, MaxWeight));
	    weight = value;
	}
    }

    public Dough(string flourType, string bakingTechnique, double weight)
    {
	FlourType = flourType;
	BakingTechnique = bakingTechnique;
	Weight = weight;
    }

    private double CalculateCalories()
    {
	double flourTypeModifier = flourTypes[FlourType.ToUpper()];
	double bakingTechniqueModifier = bakingTechniques[BakingTechnique.ToUpper()];
	return Weight * BaseCaloriesModifier * flourTypeModifier * bakingTechniqueModifier;
    }
}
