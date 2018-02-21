using System;
using System.Collections.Generic;

public class Player
{
    private string name;
    private const string InvalidName = "A name should not be empty.";
    private const int MinStatValue = 0;
    private const int MaxStatValue = 100;
    public int Endurance => statistics["Endurance"];
    public int Sprint => statistics["Sprint"];
    public int Dribble => statistics["Dribble"];
    public int Passing => statistics["Passing"];
    public int Shooting => statistics["Shooting"];
    private const string InvalidStat = "{0} should be between 0 and 100.";

    public string Name
    {
	get { return name; }
	protected set
	{
	    if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
		throw new ArgumentException(InvalidName);
	    name = value;
	}
    }

    Dictionary<string, int> statistics = new Dictionary<string, int>()
    {
	["Endurance"] = 0,
	["Sprint"] = 0,
	["Dribble"] = 0,
	["Passing"] = 0,
	["Shooting"] = 0
    };

    public Player(string name, Dictionary<string, int> stats)
    {
	SetStats(stats);
	Name = name;
    }

    private void SetStats(Dictionary<string, int> stats)
    {
	if (stats != null)
	{
	    foreach (var stat in stats)
	    {
		if (stat.Value < MinStatValue || stat.Value > MaxStatValue)
		    throw new ArgumentException(String.Format(InvalidStat, stat.Key));
		else statistics[stat.Key] = stat.Value;
	    }
	}
    }
}
