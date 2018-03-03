using System;

public class Mouse : Mammal
{
    protected override double WeightGainMultiplier => 0.1;
    protected override Type[] PreferredFoods => new Type[] {
	typeof(Fruit), typeof(Vegetable) };

    public Mouse(string name, double weight, string livingRegion)
	: base(name, weight, livingRegion) { }

    public override void ProduceSound()
    {
	Console.WriteLine("Squeak");
    }
}
