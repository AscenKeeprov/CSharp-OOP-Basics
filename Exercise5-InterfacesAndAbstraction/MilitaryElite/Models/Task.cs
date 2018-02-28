public abstract class Task : IPerformable
{
    public string Name { get; protected set; }

    public Task(string name)
    {
	Name = name;
    }

    public override string ToString()
    {
	return $"Name: {Name}";
    }
}
