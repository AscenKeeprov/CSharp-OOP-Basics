public class Truck : Vehicle
{
    protected override double FuelRetentionMultiplierTankDamage => 0.95;

    protected override double FuelConsumptionModifierSeason
    {
	get
	{
	    switch (Nature.currentSeason)
	    {
		case ESeason.Spring:
		    return 1.2;
		case ESeason.Summer:
		    return 1.6;
		case ESeason.Autumn:
		    return 1.4;
		case ESeason.Winter:
		    return 1.8;
		default:
		    return 0;
	    }
	}
    }

    public Truck(double fuelReservesInLitres, double fuelConsumptionInLitresPerKilometre, double tankCapacity)
	: base(fuelReservesInLitres, fuelConsumptionInLitresPerKilometre, tankCapacity) { }
}
