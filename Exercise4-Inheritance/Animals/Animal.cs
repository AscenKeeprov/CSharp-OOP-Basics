using System;
using System.Text;

public class Animal : ISoundProducable
{
    private const string InvalidInput = "Invalid input!";
    private string name;
    private int age;
    private string gender;

    public string Name
    {
	get { return name; }
	set
	{
	    if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
		throw new ArgumentException(InvalidInput);
	    name = value;
	}
    }

    public int Age
    {
	get { return age; }
	set
	{
	    if (value < 0) throw new ArgumentException(InvalidInput);
	    age = value;
	}
    }

    public string Gender
    {
	get { return gender; }
	set
	{
	    if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
		throw new ArgumentException(InvalidInput);
	    gender = value;
	}
    }

    public Animal(string name, int age, string gender)
    {
	Name = name;
	Age = age;
	Gender = gender;
    }

    public virtual string ProduceSound()
    {
	return "NOISE";
    }

    public override string ToString()
    {
	StringBuilder animalInfo = new StringBuilder();
	animalInfo.AppendLine(GetType().Name);
	animalInfo.AppendLine($"{Name} {Age} {Gender}");
	animalInfo.AppendLine(ProduceSound());
	return animalInfo.ToString().TrimEnd();
    }
}
