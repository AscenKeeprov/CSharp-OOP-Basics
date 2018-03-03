using System;

public abstract class Bird : Animal
{
    public double WingSize { get; protected set; }
    protected override double WeightGainMultiplier => base.WeightGainMultiplier;
    protected override Type[] PreferredFoods => base.PreferredFoods;

    public Bird(string name, double weight, double wingSize) : base(name, weight)
    {
	WingSize = wingSize;
    }

    public override string ToString()
    {
	return String.Format(base.ToString(), $" {WingSize},", String.Empty);
    }
}
