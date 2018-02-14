using System;
using System.Collections.Generic;

public class Person
{
    private string name;

    public string Name
    {
	get { return name; }
	set { name = value; }
    }

    private int age;

    public int Age
    {
	get { return age; }
	set { age = value; }
    }

    private string birthday;

    public string Birthday
    {
	get { return birthday; }
	set { birthday = value; }
    }

    private List<Person> parents;

    public List<Person> Parents
    {
	get { return parents; }
	set { parents = value; }
    }

    private List<Person> children;

    public List<Person> Children
    {
	get { return children; }
	set { children = value; }
    }

    public Person()
    {
	Name = String.Empty;
	Birthday = String.Empty;
	Children = new List<Person>();
	Parents = new List<Person>();
    }
}
