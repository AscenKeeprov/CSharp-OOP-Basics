public class Wizard
{
    public string Name { get; protected set; }
    public int MoodPoints { get; protected set; }

    public Wizard(string name)
    {
	Name = name;
    }

    internal void Eat(Food food)
    {
	MoodPoints += food.MoodModifier;
    }
}
