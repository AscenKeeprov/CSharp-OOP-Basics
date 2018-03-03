using System;

public class Hen : Bird
{
    protected override double WeightGainMultiplier => 0.35;

    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    public override void ProduceSound()
    {
	Console.WriteLine("Cluck");
    }
}
