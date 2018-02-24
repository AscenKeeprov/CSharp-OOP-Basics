using System;

public class Child : Person
{
    private const string InvalidAge = "Child's age must be less than 15!";

    public override int Age
    {
	get => base.Age;
	set
	{
	    if (value > 15)
		throw new ArgumentException(InvalidAge);
	    base.Age = value;
	}
    }

    public Child(string name, int age) : base(name, age)
    {
    }

    public override string ToString()
    {
	return $"Name: {Name}, Age: {Age}";
    }
}
