public class Individual : IIdentifiable
{
    public string Name { get; set; }
    public string Id { get; set; }

    public Individual(string name, string id)
    {
	Name = name;
	Id = id;
    }
}
