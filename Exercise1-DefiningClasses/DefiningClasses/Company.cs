using System.Collections.Generic;
using System.Linq;

public class Company
{
    public string Name { get; set; }
    public List<Department> Departments { get; set; }

    public Company()
    {
	Departments = new List<Department>();
    }

    public override string ToString()
    {
	return $"{Name} {Departments.Last().Name}";
    }
}
