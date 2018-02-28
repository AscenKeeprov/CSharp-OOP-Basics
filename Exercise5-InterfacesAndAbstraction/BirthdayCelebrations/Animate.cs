public abstract class Animate : INameable, IBirthable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Birthdate { get; set; }

    public Animate(string name)
    {
	Name = name;
    }

    public Animate(string name, int age) : this(name)
    {
	Age = age;
    }

    public Animate(string name, string birthdate) : this(name)
    {
	Birthdate = birthdate;
    }

    public Animate(string name, int age, string birthdate) : this(name, age)
    {
	Birthdate = birthdate;
    }
}
