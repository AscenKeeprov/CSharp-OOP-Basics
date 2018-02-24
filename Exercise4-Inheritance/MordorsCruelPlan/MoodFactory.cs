public class MoodFactory : Factory
{
    internal override Product Produce(int moodPoints)
    {
	if (moodPoints < -5)
	    return new Mood("Angry");
	else if (moodPoints >= -5 && moodPoints <= 0)
	    return new Mood("Sad");
	else if (moodPoints >= 1 && moodPoints <= 15)
	    return new Mood("Happy");
	else return new Mood("JavaScript");
    }
}
