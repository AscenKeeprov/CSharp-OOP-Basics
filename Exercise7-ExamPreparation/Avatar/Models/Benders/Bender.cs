using System;
using System.Text;

namespace Avatar.Models.Benders
{
    public abstract class Bender
    {
	public string Name { get; protected set; }
	public string Type { get; protected set; }
	public int Power { get; protected set; }
	public double TotalPower => (double)Power * PrimaryAttribute;
	public double PrimaryAttribute { get; set; }

	public Bender(string name, int power, double primaryAttribute)
	{
	    Name = name;
	    Type = GetType().Name.Replace("Bender", String.Empty);
	    Power = power;
	    PrimaryAttribute = primaryAttribute;
	}

	public override string ToString()
	{
	    StringBuilder benderInfo = new StringBuilder();
	    benderInfo.Append($"{Type} Bender:");
	    benderInfo.Append($" {Name}");
	    benderInfo.Append($", Power: {Power}");
	    if (Type == "Air")
		benderInfo.Append($", Aerial Integrity: {PrimaryAttribute:F2}");
	    else if (Type == "Water")
		benderInfo.Append($", Water Clarity: {PrimaryAttribute:F2}");
	    else if (Type == "Fire")
		benderInfo.Append($", Heat Aggression: {PrimaryAttribute:F2}");
	    else if (Type == "Earth")
		benderInfo.Append($", Ground Saturation: {PrimaryAttribute:F2}");
	    return benderInfo.ToString().TrimEnd();
	}
    }
}
