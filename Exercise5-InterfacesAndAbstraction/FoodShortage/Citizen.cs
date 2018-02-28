public class Citizen : Person, IIdentifiable
{
    public string Id { get; set; }

    public Citizen(string name, int age, string id, string birthdate)
	: base (name, age, birthdate)
    {
	Id = id;
    }

    public override void BuyFood()
    {
	Food += 10;
    }
}
