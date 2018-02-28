using System.Collections.Generic;

public interface ICommando : ISpecialisedSoldier
{
    List<Mission> Missions { get; set; }
    void CompleteMission(Mission mission);
}
