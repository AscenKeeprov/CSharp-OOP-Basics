using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private const string InvalidName = "A name should not be empty.";
    private List<Player> Players { get; set; }
    public int Rating => CalculateRating();

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

    public Team()
    {
	Players = new List<Player>();
    }

    public Team(string name) : this()
    {
	Name = name;
    }

    internal void AddPlayer(Player player)
    {
	if (!Players.Any(p => p.Name == player.Name)) Players.Add(player);
    }

    private int GetAveragePlayerSkillLevel(Player player)
    {
	int playerSkillLevel = player.Endurance + player.Sprint
	    + player.Dribble + player.Passing + player.Shooting;
	double playerAverageSkillLevel = Math.Round(playerSkillLevel / 5.00, 0);
	return (int)playerAverageSkillLevel;
    }

    internal void RemovePlayer(string playerName)
    {
	Player player = Players.First(p => p.Name == playerName);
	Players.Remove(player);
    }

    private int CalculateRating()
    {
	if (Players.Count > 0)
	{
	    int teamSkillLevel = 0;
	    foreach (Player player in Players)
	    {
		teamSkillLevel += GetAveragePlayerSkillLevel(player);
	    }
	    double teamAverageSkillLevel = Math.Round(teamSkillLevel / (double)Players.Count, 0);
	    return (int)teamAverageSkillLevel;
	}
	else return 0;
    }
}
