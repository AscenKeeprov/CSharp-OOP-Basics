public class Citizen : Individual
{
    public int Age { get; set; }

    public Citizen(string name, int age, string id) : base(name, id)
    {
	Age = age;
    }
}
