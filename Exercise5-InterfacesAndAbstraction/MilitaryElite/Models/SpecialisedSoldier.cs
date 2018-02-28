using System;
using System.Linq;
using System.Text;

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    private string corps;
    private string[] validCorps = { "Airforces", "Marines" };

    public string Corps
    {
	get { return corps; }
	set
	{
	    if (!validCorps.Contains(value))
		throw new ArgumentException("Invalid corps!");
	    corps = value;
	}
    }

    public SpecialisedSoldier(int id, string firstName, string lastName,
	double salary, string corps)
	: base(id, firstName, lastName, salary)
    {
	Corps = corps;
    }

    public override string ToString()
    {
	StringBuilder specSoldierInfo = new StringBuilder();
	specSoldierInfo.AppendLine(base.ToString());
	specSoldierInfo.AppendLine($"{nameof(Corps)}: {Corps}");
	return specSoldierInfo.ToString();
    }
}
