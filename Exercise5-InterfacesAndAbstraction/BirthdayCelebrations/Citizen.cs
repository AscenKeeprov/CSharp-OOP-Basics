public class Citizen : Animate, IIdentifiable
{
    public string Id { get; set; }

    public Citizen(string name, int age, string id, string birthdate)
	: base(name, age, birthdate)
    {
	Id = id;
    }
}
