using System;

public class Dog : Mammal
{
    protected override double WeightGainMultiplier => 0.4;
    protected override Type[] PreferredFoods => new Type[] { typeof(Meat) };

    public Dog(string name, double weight, string livingRegion)
	: base(name, weight, livingRegion) { }

    public override void ProduceSound()
    {
	Console.WriteLine("Woof!");
    }
}
