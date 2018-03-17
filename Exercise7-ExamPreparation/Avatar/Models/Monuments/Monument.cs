using System;
using System.Text;

namespace Avatar.Models.Monuments
{
    public abstract class Monument
    {
	public string Name { get; protected set; }
	public string Type { get; protected set; }
	public int Affinity { get; protected set; }

	public Monument(string name, int affinity)
	{
	    Name = name;
	    Type = GetType().Name.Replace("Monument", String.Empty);
	    Affinity = affinity;
	}

	public override string ToString()
	{
	    StringBuilder monumentInfo = new StringBuilder();
	    monumentInfo.Append($"{Type} Monument:");
	    monumentInfo.Append($" {Name}");
	    monumentInfo.Append($", {Type} Affinity: {Affinity}");
	    return monumentInfo.ToString().TrimEnd();
	}
    }
}
