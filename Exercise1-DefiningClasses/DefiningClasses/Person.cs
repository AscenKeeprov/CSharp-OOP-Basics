public class Person
{
    private string name;

    public string Name
    {
	get { return name; }
	set { name = value; }
    }

    private int age;

    public int Age
    {
	get { return age; }
	set { age = value; }
    }

    public Person()
    {
	name = "No name";
	age = -1;
    }

    public Person(string name) : this()
    {
	this.name = name;
    }

    public Person(int age) : this()
    {
	this.age = age;
    }

    public Person(string name, int age)
    {
	this.age = age;
	this.name = name;
    }
}
