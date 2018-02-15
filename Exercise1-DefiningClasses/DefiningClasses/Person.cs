using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    public string Name { get; set; }
    public string Birthday { get; set; }
    public List<Person> Parents { get; set; }
    public List<Person> Children { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public Car Car { get; set; }
    public Company Company { get; set; }
    public decimal Salary { get; set; }

    public Person()
    {
	Name = String.Empty;
	Birthday = String.Empty;
	Company = new Company();
	Salary = 0M;
	Pokemons = new List<Pokemon>();
	Parents = new List<Person>();
	Children = new List<Person>();
	Car = new Car();
    }

    public override string ToString()
    {
	StringBuilder report = new StringBuilder();
	report.AppendLine(Name);
	report.AppendLine("Company:");
	if (!String.IsNullOrEmpty(Company.Name))
	    report.AppendLine($"{Company.ToString()} {Salary}");
	report.AppendLine("Car:");
	if (!String.IsNullOrEmpty(Car.Model))
	    report.AppendLine(Car.ToString());
	report.AppendLine("Pokemon:");
	if (Pokemons.Count > 0)
	{
	    foreach (Pokemon pokemon in Pokemons)
		report.AppendLine(pokemon.ToString());
	}
	report.AppendLine("Parents:");
	if (Parents.Count > 0)
	{
	    foreach (Person parent in Parents)
		report.AppendLine($"{parent.Name} {parent.Birthday}");
	}
	report.AppendLine("Children:");
	if (Children.Count > 0)
	{
	    foreach (Person child in Children)
		report.AppendLine($"{child.Name} {child.Birthday}");
	}
	return report.ToString().Trim();
    }
}
