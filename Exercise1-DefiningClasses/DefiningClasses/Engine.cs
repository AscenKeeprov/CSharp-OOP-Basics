using System;

public class Engine
{
    public string Model { get; set; }
    public int Power { get; set; }
    public int Speed { get; set; }
    public int Displacement { get; set; }
    public string Efficiency { get; set; }

    public Engine(int power, int speed)
    {
	Power = power;
	Speed = speed;
    }

    public Engine(string model, int power)
    {
	Model = model;
	Power = power;
    }

    public override string ToString()
    {
	string displacement = "n/a";
	if (Displacement != 0) displacement = Displacement.ToString();
	string efficiency = "n/a";
	if (Efficiency != null) efficiency = Efficiency;
	return $"{Model}:{Environment.NewLine}" +
	    $"    Power: {Power}{Environment.NewLine}" +
	    $"    Displacement: {displacement}{Environment.NewLine}" +
	    $"    Efficiency: {efficiency}";
    }
}
