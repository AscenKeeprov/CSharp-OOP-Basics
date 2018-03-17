using System.Collections.Generic;
using System.Linq;
using System.Text;
using Avatar.Models.Benders;
using Avatar.Models.Monuments;
using Avatar.Models.Nations;

namespace Avatar
{
    public static class NationsBuilder
    {
	private static List<Nation> nations = new List<Nation>();
	private static List<string> wars = new List<string>();

	public static void CreateNations()
	{
	    nations.Add(new AirNation());
	    nations.Add(new WaterNation());
	    nations.Add(new FireNation());
	    nations.Add(new EarthNation());
	}

	public static void AssignBender(List<string> benderArgs)
	{
	    Bender bender = BenderFactory.CreateBender(benderArgs);
	    Nation nation = nations.SingleOrDefault(n => n.Type == bender.Type);
	    if (nation != null) nation.Benders.Add(bender);
	}

	public static void AssignMonument(List<string> monumentArgs)
	{
	    Monument monument = MonumentFactory.CreateMonument(monumentArgs);
	    Nation nation = nations.SingleOrDefault(n => n.Type == monument.Type);
	    if (nation != null) nation.Monuments.Add(monument);
	}

	public static string GetStatus(string nationType)
	{
	    Nation nation = nations.SingleOrDefault(n => n.Type == nationType);
	    return nation.ToString();
	}

	public static void IssueWar(string nationType)
	{
	    wars.Add($"War {wars.Count + 1} issued by {nationType}");
	    int highestNationPower = nations.Max(n => n.Power);
	    foreach (Nation nation in nations)
	    {
		if (nation.Power != highestNationPower)
		{
		    nation.Benders.Clear();
		    nation.Monuments.Clear();
		}
	    }
	}

	public static string GetWarsRecord()
	{
	    StringBuilder warsInfo = new StringBuilder();
	    foreach (string war in wars)
	    {
		warsInfo.AppendLine(war);
	    }
	    return warsInfo.ToString().TrimEnd();
	}
    }
}
