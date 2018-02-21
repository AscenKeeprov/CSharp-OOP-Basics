using System;

public class Product
{
    public string Name { get; protected set; }
    public decimal Price { get; protected set; }

    internal Product(string name, decimal price)
    {
	if (IsValidName(name) && IsValidPrice(price))
	{
	    Name = name;
	    Price = price;
	}
	else
	{
	    if (!IsValidName(name)) Console.WriteLine("Name cannot be empty");
	    if (!IsValidPrice(price)) Console.WriteLine("Money cannot be negative");
	    throw new ArgumentOutOfRangeException();
	}
    }

    private bool IsValidName(string name)
    {
	return !String.IsNullOrEmpty(name) && !String.IsNullOrWhiteSpace(name);
    }

    private bool IsValidPrice(decimal? price)
    {
	return price != null && price > 0M;
    }
}
