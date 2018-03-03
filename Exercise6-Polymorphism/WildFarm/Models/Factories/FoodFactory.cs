using System;

public class FoodFactory : Factory
{
    internal Food Produce(string foodType, int foodQuantity)
    {
	Type typeOfFood = ToProperType(foodType);
	Food food = (Food)Activator.CreateInstance(typeOfFood, foodQuantity);
	return food;
    }
}
