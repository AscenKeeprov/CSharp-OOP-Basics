public class Inanimate : INameable, IIdentifiable
{
    public string Name { get; set; }
    public string Id { get; set; }

    public Inanimate(string model, string id)
    {
	Name = model;
	Id = id;
    }
}
