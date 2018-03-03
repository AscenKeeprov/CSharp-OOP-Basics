using System;
using System.Linq;

public abstract class Animal
{
    public string Name { get; protected set; }
    public double Weight { get; protected set; }
    protected virtual double WeightGainMultiplier => 1;
    public int FoodEaten { get; protected set; }
    protected virtual Type[] PreferredFoods => new Type[] {
	typeof(Fruit), typeof(Meat), typeof(Seeds), typeof(Vegetable) };
    private const string FoodNotPreferred = "{0} does not eat {1}!";

    public Animal(string name, double weight)
    {
	Name = name;
	Weight = weight;
	FoodEaten = 0;
    }

    public virtual void ProduceSound() { }

    public void Eat(Food food)
    {
	if (!PreferredFoods.Contains(food.GetType()))
	    throw new ArgumentException(String.Format(
		FoodNotPreferred, GetType().Name, food.GetType()));
	FoodEaten += food.Quantity;
	Weight += food.Quantity * WeightGainMultiplier;
    }

    public override string ToString()
    {
	return $"{GetType().Name} [{Name}," + "{0}" + $" {Weight}," + "{1}" + $" {FoodEaten}]";
    }
}
