public class Bus : Vehicle
{
    protected override double FuelConsumptionModifierPassengers => 1.4;

    public Bus(double fuelReservesInLitres, double fuelConsumptionInLitresPerKilometre, double tankCapacity)
	: base(fuelReservesInLitres, fuelConsumptionInLitresPerKilometre, tankCapacity) { }
}
