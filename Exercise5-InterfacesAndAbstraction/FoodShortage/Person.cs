public abstract class Person : INameable, IBirthable, IBuyer
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Birthdate { get; set; }
    public int Food { get; set; }

    public Person(string name)
    {
	Name = name;
    }

    public Person(string name, int age) : this(name)
    {
	Age = age;
    }

    public Person(string name, string birthdate) : this(name)
    {
	Birthdate = birthdate;
    }

    public Person(string name, int age, string birthdate) : this(name, age)
    {
	Birthdate = birthdate;
    }

    public virtual void BuyFood()
    {
	Food += 5;
    }
}
