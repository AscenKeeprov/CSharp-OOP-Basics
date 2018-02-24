using System;

public class FoodFactory : Factory
{
    internal override Product Produce(string foodType)
    {
	switch (foodType.ToUpper())
	{
	    case "APPLE":
	    case "CRAM":
	    case "HONEYCAKE":
	    case "LEMBAS":
	    case "MELON":
	    case "MUSHROOMS":
		return new Food(foodType, (int)Enum.Parse(typeof(FoodType), foodType.ToUpper()));
	    default:
		return new Food("Junk", (int)FoodType.JUNK);
	}
    }
}
