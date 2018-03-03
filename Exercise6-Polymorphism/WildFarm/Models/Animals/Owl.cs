using System;

public class Owl : Bird
{
    protected override double WeightGainMultiplier => 0.25;
    protected override Type[] PreferredFoods => new Type[] { typeof(Meat) };

    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    public override void ProduceSound()
    {
	Console.WriteLine("Hoot Hoot");
    }
}
