using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; protected set; }
    public decimal Money { get; protected set; }
    public List<Product> Bag { get; set; }

    internal Person(string name, decimal money)
    {
	if (IsValidName(name) && IsValidMoney(money))
	{
	    Name = name;
	    Money = money;
	}
	else
	{
	    if (!IsValidName(name)) Console.WriteLine("Name cannot be empty");
	    if (!IsValidMoney(money)) Console.WriteLine("Money cannot be negative");
	    throw new ArgumentOutOfRangeException();
	}
	Bag = new List<Product>();
    }

    private bool IsValidName(string name)
    {
	return !String.IsNullOrEmpty(name) && !String.IsNullOrWhiteSpace(name);
    }

    private bool IsValidMoney(decimal? money)
    {
	return money != null && money >= 0M;
    }

    public void TryPurchase(Product product)
    {
	if (Money >= product.Price)
	{
	    Money -= product.Price;
	    Bag.Add(product);
	    Console.WriteLine($"{Name} bought {product.Name}");
	}
	else Console.WriteLine($"{Name} can't afford {product.Name}");
    }
}
