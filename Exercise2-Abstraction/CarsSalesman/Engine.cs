using System.Text;

public class Engine
{
    public string Model { get; set; }
    public int Power { get; set; }
    public int Displacement { get; set; }
    public string Efficiency { get; set; }

    public Engine()
    {
	Model = "Unknown";
	Power = -1;
	Displacement = -1;
	Efficiency = "n/a";
    }

    public Engine(string model, int power) : this()
    {
	Model = model;
	Power = power;
    }

    public Engine(string model, int power, int displacement) : this(model, power)
    {
	Displacement = displacement;
    }

    public Engine(string model, int power, string efficiency) : this(model, power)
    {
	Efficiency = efficiency;
    }

    public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
    {
	Displacement = displacement;
	Efficiency = efficiency;
    }

    public override string ToString()
    {
	StringBuilder engineInfo = new StringBuilder();
	engineInfo.AppendLine($"  {Model}:");
	engineInfo.AppendLine($"    Power: {Power}");
	engineInfo.AppendLine($"    Displacement: {(Displacement == -1 ? "n/a" : $"{Displacement}")}");
	engineInfo.AppendLine($"    Efficiency: {Efficiency}");
	return engineInfo.ToString().TrimEnd();
    }
}
