public class Rebel : Person, IGroupable
{
    public string Group { get; set; }

    public Rebel(string name, int age, string group) : base(name, age)
    {
	Group = group;
    }
}
