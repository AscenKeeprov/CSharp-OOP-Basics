using System.Collections.Generic;

public class Family
{
    private List<Person> people;

    public List<Person> People
    {
	get { return people; }
	set { people = value; }
    }

    public Family()
    {
	People = new List<Person>();
    }
}
