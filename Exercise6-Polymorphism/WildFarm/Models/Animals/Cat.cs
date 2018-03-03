using System;

public class Cat : Feline
{
    protected override double WeightGainMultiplier => 0.3;
    protected override Type[] PreferredFoods => new Type[] {
	typeof(Meat), typeof(Vegetable) };

    public Cat(string name, double weight, string livingRegion, string breed)
	: base(name, weight, livingRegion, breed) { }

    public override void ProduceSound()
    {
	Console.WriteLine("Meow");
    }
}
