using System;
using System.Collections.Generic;
using System.Linq;

namespace Avatar
{
    class Program
    {
	static void Main()
	{
	    NationsBuilder.CreateNations();
	    string input;
	    while ((input = Console.ReadLine()) != "Quit")
	    {
		List<string> parameters = input.Split().ToList();
		string command = parameters[0];
		try
		{
		    switch (command.ToUpper())
		    {
			case "BENDER":
			    NationsBuilder.AssignBender(parameters);
			    break;
			case "MONUMENT":
			    NationsBuilder.AssignMonument(parameters);
			    break;
			case "STATUS":
			    string nationType = parameters[1];
			    Console.WriteLine(NationsBuilder.GetStatus(nationType));
			    break;
			case "WAR":
			    nationType = parameters[1];
			    NationsBuilder.IssueWar(nationType);
			    break;
		    }
		}
		catch (Exception exception)
		{
		    Console.WriteLine(exception.Message);
		}
	    }
	    Console.WriteLine(NationsBuilder.GetWarsRecord());
	}
    }
}
