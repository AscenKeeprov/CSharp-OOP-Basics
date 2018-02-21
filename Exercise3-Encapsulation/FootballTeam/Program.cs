using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private const string InexistentTeam = "Team {0} does not exist.";
    private const string PlayerNotInTeam = "Player {0} is not in {1} team.";

    static void Main()
    {
	Dictionary<Team, List<string>> league = new Dictionary<Team, List<string>>();
	string command;
	while (!(command = Console.ReadLine()).Equals("END"))
	{
	    try
	    {
		string[] commandParameters = command.Split(';');
		string action = commandParameters[0];
		if (action.ToUpper().Equals("ADD"))
		    AddPlayerToTeam(commandParameters, league);
		else if (action.ToUpper().Equals("RATING"))
		    RateTeam(commandParameters, league);
		else if (action.ToUpper().Equals("REMOVE"))
		    RemovePlayerFromTeam(commandParameters, league);
		else if (action.ToUpper().Equals("TEAM"))
		    CreateTeam(commandParameters, league);
	    }
	    catch (ArgumentException exception)
	    {
		Console.WriteLine(exception.Message);
	    }
	}
    }

    private static void CreateTeam(string[] commandParameters, Dictionary<Team, List<string>> league)
    {
	string teamName = commandParameters[1];
	if (!league.Keys.Any(t => t.Name == teamName))
	    league.Add(new Team(teamName), new List<string>());
    }

    private static void AddPlayerToTeam(string[] commandParameters, Dictionary<Team, List<string>> league)
    {
	string teamName = commandParameters[1];
	if (!league.Keys.Any(t => t.Name == teamName))
	    Console.WriteLine(String.Format(InexistentTeam, teamName));
	else
	{
	    Team team = league.Keys.First(t => t.Name == teamName);
	    string playerName = commandParameters[2];
	    Dictionary<string, int> playerStats = new Dictionary<string, int>()
	    {
		["Endurance"] = int.Parse(commandParameters[3]),
		["Sprint"] = int.Parse(commandParameters[4]),
		["Dribble"] = int.Parse(commandParameters[5]),
		["Passing"] = int.Parse(commandParameters[6]),
		["Shooting"] = int.Parse(commandParameters[7])
	    };
	    team.AddPlayer(new Player(playerName, playerStats));
	    league[team].Add(playerName);
	}
    }

    private static void RemovePlayerFromTeam(string[] commandParameters, Dictionary<Team, List<string>> league)
    {
	string teamName = commandParameters[1];
	if (!league.Keys.Any(t => t.Name == teamName))
	    Console.WriteLine(String.Format(InexistentTeam, teamName));
	else
	{
	    Team team = league.Keys.First(t => t.Name == teamName);
	    string playerName = commandParameters[2];
	    if (!league[team].Any(p => p == playerName))
		Console.WriteLine(String.Format(PlayerNotInTeam, playerName, teamName));
	    else
	    {
		team.RemovePlayer(playerName);
		league[team].Remove(playerName);
	    }
	}
    }

    private static void RateTeam(string[] commandParameters, Dictionary<Team, List<string>> league)
    {
	string teamName = commandParameters[1];
	if (!league.Keys.Any(t => t.Name == teamName))
	    Console.WriteLine(String.Format(InexistentTeam, teamName));
	else
	{
	    Team team = league.Keys.First(t => t.Name == teamName);
	    Console.WriteLine($"{team.Name} - {team.Rating}");
	}
    }
}
