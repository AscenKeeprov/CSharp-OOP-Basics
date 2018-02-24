public class Food : Product
{
    public int MoodModifier { get; protected set; }

    public Food(string foodType, int moodModifier) : base(foodType)
    {
	MoodModifier = moodModifier;
    }
}
