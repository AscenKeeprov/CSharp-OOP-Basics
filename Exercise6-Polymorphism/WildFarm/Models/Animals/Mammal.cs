using System;

public abstract class Mammal : Animal
{
    public string LivingRegion { get; protected set; }

    public Mammal(string name, double weight, string livingRegion) : base(name, weight)
    {
	LivingRegion = livingRegion;
    }

    public override string ToString()
    {
	string breed = String.Empty;
	if (this is Feline) breed = "{0}";
	return String.Format(base.ToString(), breed, $" {LivingRegion},");
    }
}
