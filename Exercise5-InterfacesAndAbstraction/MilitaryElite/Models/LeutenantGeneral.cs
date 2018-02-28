using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LieutenantGeneral : Private, ILeutenantGeneral
{
    public List<Private> Privates { get; private set; }

    public LieutenantGeneral(int id, string firstName, string lastName,
	double salary) : base(id, firstName, lastName, salary)
    {
	Privates = new List<Private>();
    }

    public void EnlistPrivate(Private recruit)
    {
	if (!Privates.Any(p => p.Id == recruit.Id))
	    Privates.Add(recruit);
    }

    public override string ToString()
    {
	StringBuilder ltGenInfo = new StringBuilder();
	ltGenInfo.AppendLine(base.ToString());
	ltGenInfo.AppendLine($"{nameof(Privates)}:");
	foreach (Private privateSoldier in Privates)
	{
	    ltGenInfo.AppendLine($"  {privateSoldier.ToString()}");
	}
	return ltGenInfo.ToString().TrimEnd();
    }
}
