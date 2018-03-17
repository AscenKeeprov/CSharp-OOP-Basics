using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Avatar.Models.Benders;
using Avatar.Models.Monuments;

namespace Avatar.Models.Nations
{
    public abstract class Nation
    {
	public string Type { get; protected set; }
	public ICollection<Bender> Benders { get; protected set; }
	public ICollection<Monument> Monuments { get; protected set; }
	public int Power => CalculatePower();

	public Nation()
	{
	    Type = GetType().Name.Replace("Nation", String.Empty);
	    Benders = new List<Bender>();
	    Monuments = new List<Monument>();
	}

	private int CalculatePower()
	{
	    double bendersPower = Benders.Sum(b => b.TotalPower);
	    int monumentsAffinity = Monuments.Sum(m => m.Affinity);
	    double affinityMultiplier = monumentsAffinity / 100;
	    return (int)(bendersPower * affinityMultiplier);
	}

	public override string ToString()
	{
	    StringBuilder nationInfo = new StringBuilder();
	    nationInfo.AppendLine($"{Type} Nation");
	    nationInfo.Append("Benders:");
	    if (Benders.Count > 0)
	    {
		nationInfo.Append(Environment.NewLine);
		foreach (Bender bender in Benders)
		{
		    nationInfo.AppendLine($"###{bender.ToString()}");
		}
	    }
	    else nationInfo.AppendLine(" None");
	    nationInfo.Append("Monuments:");
	    if (Monuments.Count > 0)
	    {
		nationInfo.Append(Environment.NewLine);
		foreach (Monument monument in Monuments)
		{
		    nationInfo.AppendLine($"###{monument.ToString()}");
		}
	    }
	    else nationInfo.AppendLine(" None");
	    return nationInfo.ToString().TrimEnd();
	}
    }
}
