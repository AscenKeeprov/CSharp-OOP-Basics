using System;

public class Tiger : Feline
{
    protected override Type[] PreferredFoods => new Type[] { typeof(Meat) };

    public Tiger(string name, double weight, string livingRegion, string breed)
	: base(name, weight, livingRegion, breed) { }

    public override void ProduceSound()
    {
	Console.WriteLine("ROAR!!!");
    }
}
