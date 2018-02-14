using System.Collections.Generic;
using System.Linq;

public class Department
{
    private string name;

    public string Name
    {
	get { return name; }
	set { name = value; }
    }

    private List<Employee> employees;

    public List<Employee> Employees
    {
	get { return employees; }
	set { employees = value; }
    }

    public decimal AverageSalary => Employees.Select(e => e.Salary).Average();

    public Department()
    {
	Employees = new List<Employee>();
    }
}
