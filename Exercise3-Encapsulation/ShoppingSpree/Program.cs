using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
	List<Person> people = new List<Person>();
	List<Product> products = new List<Product>();
	string[] peopleInfo = Console.ReadLine().Trim()
	    .Split(';', StringSplitOptions.RemoveEmptyEntries);
	foreach (string person in peopleInfo)
	{
	    string[] personInfo = person.Split('=');
	    string personName = personInfo[0];
	    decimal personMoney = decimal.Parse(personInfo[1]);
	    try
	    {
		Person shopper = new Person(personName, personMoney);
		people.Add(shopper);
	    }
	    catch (ArgumentOutOfRangeException)
	    {
		Environment.Exit(160);
	    }
	}
	string[] productsInfo = Console.ReadLine().Trim()
	    .Split(';', StringSplitOptions.RemoveEmptyEntries);
	foreach (string product in productsInfo)
	{
	    string[] productInfo = product.Split('=');
	    string productName = productInfo[0];
	    decimal productPrice = decimal.Parse(productInfo[1]);
	    try
	    {
		Product commodity = new Product(productName, productPrice);
		products.Add(commodity);
	    }
	    catch (ArgumentOutOfRangeException)
	    {
		Environment.Exit(160);
	    }
	}
	string shoppingSpree;
	while (!(shoppingSpree = Console.ReadLine().Trim()).Equals("END"))
	{
	    string[] purchaseInfo = shoppingSpree.Split();
	    string shopperName = purchaseInfo[0];
	    string commodityName = purchaseInfo[1];
	    if (!people.Any(person => person.Name == shopperName) ||
		!products.Any(product => product.Name == commodityName)) continue;
	    Person shopper = people.First(person => person.Name == shopperName);
	    Product commodity = products.First(product => product.Name == commodityName);
	    shopper.TryPurchase(commodity);
	}
	foreach (Person person in people)
	{
	    Console.Write($"{person.Name} - ");
	    if (person.Bag.Count > 0) Console.WriteLine(
		String.Join(", ", person.Bag.Select(product => product.Name)));
	    else Console.WriteLine("Nothing bought");
	}
    }
}
