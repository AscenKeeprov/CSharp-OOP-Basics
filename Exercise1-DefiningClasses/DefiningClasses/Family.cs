using System.Collections.Generic;
using System.Linq;

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

    public void AddMember(Person member)
    {
	People.Add(member);
    }

    public Person GetOldestMember()
    {
	return People.OrderByDescending(p => p.Age).FirstOrDefault();
    }
}
