using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public List<Repair> Repairs { get; set; }

    public Engineer(int id, string firstName, string lastName,
	double salary, string corps)
	: base(id, firstName, lastName, salary, corps)
    {
	Repairs = new List<Repair>();
    }

    public void ScheduleRepair(Repair repair)
    {
	if (Repairs.Any(r => r.Name == repair.Name))
	{
	    Repair ongoingRepair = Repairs.First(r => r.Name == repair.Name);
	    ongoingRepair.HoursWorked += repair.HoursWorked;
	}
	else Repairs.Add(repair);
    }

    public override string ToString()
    {
	StringBuilder engineerInfo = new StringBuilder(base.ToString());
	engineerInfo.Append($"{nameof(Repairs)}:");
	if (Repairs.Count > 0) engineerInfo.AppendLine();
	foreach (Repair repair in Repairs)
	{
	    engineerInfo.AppendLine($"  {repair.ToString()}");
	}
	return engineerInfo.ToString().TrimEnd();
    }
}
