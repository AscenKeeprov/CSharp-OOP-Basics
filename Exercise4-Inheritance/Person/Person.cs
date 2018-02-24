using System;

public class Person
{
    private string name;
    private const string InvalidName = "Name's length should not be less than 3 symbols!";
    private int age;
    private const string InvalidAge = "Age must be positive!";

    public virtual string Name
    {
	get { return name; }
	set
	{
	    if (value.Length < 3)
		throw new ArgumentException(InvalidName);
	    name = value;
	}
    }

    public virtual int Age
    {
	get { return age; }
	set
	{
	    if (value < 0) throw new ArgumentException(InvalidAge);
	    age = value;
	}
    }

    public Person(string name, int age)
    {
	Name = name;
	Age = age;
    }
}
