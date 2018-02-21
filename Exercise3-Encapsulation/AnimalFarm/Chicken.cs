using System;

public class Chicken
{
    public string Name { get; protected set; }
    public int Age { get; protected set; }
    private const int minAge = 0;
    private const int maxAge = 15;
    public double LayPerDay => CalculateLayPerDay();

    internal Chicken(string name, int age)
    {
	if (IsValidName(name) && IsValidAge(age))
	{
	    Name = name;
	    Age = age;
	}
	else
	{
	    if (!IsValidName(name)) Console.WriteLine("Name cannot be empty.");
	    if (!IsValidAge(age)) Console.WriteLine("Age should be between 0 and 15.");
	    throw new ArgumentOutOfRangeException();
	}
    }

    private bool IsValidName(string name)
    {
	return !String.IsNullOrEmpty(name) && !String.IsNullOrWhiteSpace(name);
    }

    private bool IsValidAge(int age)
    {
	return age >= minAge && age <= maxAge;
    }

    private double CalculateLayPerDay()
    {
	if (Age >= 0 && Age <= 3) return 1.5;
	else if (Age >= 4 && Age <= 7) return 2;
	else if (Age >= 8 && Age <= 11) return 1;
	else return 0.75;
    }
}
