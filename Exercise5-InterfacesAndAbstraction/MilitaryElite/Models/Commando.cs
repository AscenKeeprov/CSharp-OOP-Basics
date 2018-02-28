using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public List<Mission> Missions { get; set; }

    public Commando(int id, string firstName, string lastName,
	double salary, string corps)
	: base(id, firstName, lastName, salary, corps)
    {
	Missions = new List<Mission>();
    }

    public void AcceptMission(Mission mission)
    {
	if (!Missions.Any(m => m.Name == mission.Name))
	    Missions.Add(mission);
    }

    public void CompleteMission(Mission mission)
    {
	if (Missions.Any(m => m.Name == mission.Name))
	{
	    Mission ongoingMission = Missions.First(m => m.Name == mission.Name);
	    if (ongoingMission.State == "inProgress" && mission.State == "Finished")
		ongoingMission.State = "Finished";
	}
	else Missions.Add(mission);
    }

    public override string ToString()
    {
	StringBuilder commandoInfo = new StringBuilder(base.ToString());
	commandoInfo.Append($"{nameof(Missions)}:");
	if (Missions.Count > 0) commandoInfo.AppendLine();
	foreach (Mission mission in Missions)
	{
	    commandoInfo.AppendLine($"  {mission.ToString()}");
	}
	return commandoInfo.ToString().TrimEnd();
    }
}
