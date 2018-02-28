using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
	List<Soldier> soldiers = new List<Soldier>();
	string input;
	while ((input = Console.ReadLine()) != "End")
	{
	    string[] soldierInfo = input.Split();
	    EnlistSoldier(soldiers, soldierInfo);
	}
	foreach (Soldier soldier in soldiers)
	{
	    Console.WriteLine(soldier);
	}
    }

    private static void EnlistSoldier(List<Soldier> soldiers, string[] soldierInfo)
    {
	string rank = soldierInfo[0];
	int id = int.Parse(soldierInfo[1]);
	string firstName = soldierInfo[2];
	string lastName = soldierInfo[3];
	double salary = double.Parse(soldierInfo[4]);
	Soldier soldier = null;
	try
	{
	    switch (rank.ToUpper())
	    {
		case "PRIVATE":
		    Private privateSoldier = new Private(id, firstName, lastName, salary);
		    soldier = privateSoldier;
		    break;
		case "LEUTENANTGENERAL":
		    LieutenantGeneral leutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);
		    if (soldierInfo.Length > 5)
		    {
			for (int i = 5; i < soldierInfo.Length; i++)
			{
			    int soldierId = int.Parse(soldierInfo[i]);
			    Private recruit = (Private)soldiers.First(s => s.Id == soldierId);
			    leutenantGeneral.EnlistPrivate(recruit);
			}
		    }
		    soldier = leutenantGeneral;
		    break;
		case "ENGINEER":
		    string corps = soldierInfo[5];
		    Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);
		    if (soldierInfo.Length > 6)
		    {
			for (int i = 6; i < soldierInfo.Length; i++)
			{
			    string partName = soldierInfo[i];
			    int hoursWorked = int.Parse(soldierInfo[++i]);
			    Repair repair = new Repair(partName, hoursWorked);
			    engineer.ScheduleRepair(repair);
			}
		    }
		    soldier = engineer;
		    break;
		case "COMMANDO":
		    corps = soldierInfo[5];
		    Commando commando = new Commando(id, firstName, lastName, salary, corps);
		    if (soldierInfo.Length > 6)
		    {
			for (int i = 6; i < soldierInfo.Length; i++)
			{
			    string codeName = soldierInfo[i];
			    string missionState = soldierInfo[++i];
			    try
			    {
				Mission mission = new Mission(codeName, missionState);
				commando.AcceptMission(mission);
			    }
			    catch { }
			}
		    }
		    soldier = commando;
		    break;
		case "SPY":
		    int codeNumber = int.Parse(soldierInfo[4]);
		    Spy spy = new Spy(id, firstName, lastName, codeNumber);
		    soldier = spy;
		    break;
		default:
		    throw new ArgumentException("Invalid rank!");
	    }
	    soldiers.Add(soldier);
	}
	catch { }
    }
}
