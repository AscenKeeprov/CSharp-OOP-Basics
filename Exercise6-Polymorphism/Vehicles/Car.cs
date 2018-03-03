public class Car : Vehicle
{
    protected override double FuelConsumptionModifierSeason
    {
	get
	{
	    switch (Nature.currentSeason)
	    {
		case ESeason.Spring:
		    return 0.5;
		case ESeason.Summer:
		    return 0.9;
		case ESeason.Autumn:
		    return 0.7;
		case ESeason.Winter:
		    return 1.1;
		default:
		    return 0;
	    }
	}
    }

    public Car(double fuelReservesInLitres, double fuelConsumptionInLitresPerKilometre, double tankCapacity)
	: base(fuelReservesInLitres, fuelConsumptionInLitresPerKilometre, tankCapacity) { }
}
