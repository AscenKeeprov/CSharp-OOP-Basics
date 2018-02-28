public class Citizen : IPerson, IBirthable, IIdentifiable
{
    public string Name { get; set; }
    public string Birthdate { get; set; }
    public string Id { get; set; }
    public int Age { get; set; }

    public Citizen(string name, int age, string id, string birthdate)
    {
	Name = name;
	Birthdate = birthdate;
	Id = id;
	Age = age;
    }
}
