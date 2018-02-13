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
	people = new List<Person>();
    }

    public void AddMember(Person member)
    {
	people.Add(member);
    }

    public Person GetOldestMember()
    {
	Person oldestMember = new Person();
	foreach (Person person in people)
	{
	    if (person.Age > oldestMember.Age && person.Name != "No name")
		oldestMember = person;
	}
	return oldestMember;
    }
}
