using System;

public abstract class Vehicle : IDrivable, IRefuelable
{
    private const string NegativeValueException = "{0} cannot be negative";
    protected const string InsufficientFuelAmount = "{0} needs refueling";
    protected const string ExcessiveFuelAmount = "Cannot fit {0} fuel in the tank";
    protected const string InvalidFuelAmount = "Fuel must be a positive number";
    private double tankCapacityInLitres;
    private const int MinTankCapacity = 0;
    private double fuelReservesInLitres;
    private const int MinFuelReservesInLitres = 0;
    private double fuelConsumptionInLitresPerKilometre;
    private const double MinFuelConsumptionInLitresPerKilometre = 0.001;
    protected virtual double FuelRetentionMultiplierTankDamage => 1;
    protected virtual double FuelConsumptionModifierSeason => 0;
    protected virtual double FuelConsumptionModifierPassengers => 0;

    public double TankCapacityInLitres
    {
	get { return tankCapacityInLitres; }
	set
	{
	    if (value < MinTankCapacity)
		throw new ArgumentOutOfRangeException(String.Format(
		    NegativeValueException, nameof(TankCapacityInLitres)));
	    tankCapacityInLitres = value;
	}
    }

    public double FuelReservesInLitres
    {
	get { return fuelReservesInLitres; }
	protected set
	{
	    if (value < MinFuelReservesInLitres)
		throw new ArgumentOutOfRangeException(String.Format(
		    NegativeValueException, nameof(FuelReservesInLitres)));
	    fuelReservesInLitres = value;
	}
    }

    public double FuelConsumptionInLitresPerKilometre
    {
	get { return fuelConsumptionInLitresPerKilometre; }
	protected set
	{
	    if (value < MinFuelConsumptionInLitresPerKilometre)
		throw new ArgumentOutOfRangeException(String.Format(
		    NegativeValueException, nameof(FuelConsumptionInLitresPerKilometre)));
	    fuelConsumptionInLitresPerKilometre = value;
	}
    }

    public Vehicle(double fuelReservesInLitres, double fuelConsumptionInLitresPerKilometre, double tankCapacity)
    {
	FuelReservesInLitres = fuelReservesInLitres <= tankCapacity ? fuelReservesInLitres : 0;
	FuelConsumptionInLitresPerKilometre = fuelConsumptionInLitresPerKilometre + FuelConsumptionModifierSeason;
	TankCapacityInLitres = tankCapacity;
    }

    private double CalculateFuelExpenditure(double distanceInKilometres, bool hasPassengers)
    {
	double fuelRequired = distanceInKilometres * FuelConsumptionInLitresPerKilometre;
	if (hasPassengers)
	    fuelRequired += distanceInKilometres * FuelConsumptionModifierPassengers;
	return fuelRequired;
    }

    public void Drive(double distanceInKilometres, bool hasPassengers)
    {
	double fuelRequired = CalculateFuelExpenditure(distanceInKilometres, hasPassengers);
	Drive(distanceInKilometres, fuelRequired);
    }

    private void Drive(double distanceInKilometres, double fuelRequired)
    {
	if (FuelReservesInLitres < fuelRequired)
	    throw new InvalidOperationException(String.Format(InsufficientFuelAmount, GetType().Name));
	else
	{
	    FuelReservesInLitres -= fuelRequired;
	    Console.WriteLine(String.Format("{0} travelled {1} km", GetType().Name, distanceInKilometres));
	}
    }

    public virtual void Refuel(double fuelAmountInLitres)
    {
	if (IsValidFuelAmount(fuelAmountInLitres))
	    FuelReservesInLitres += fuelAmountInLitres * FuelRetentionMultiplierTankDamage;
    }

    public bool IsValidFuelAmount(double fuelAmountInLitres)
    {
	if (fuelAmountInLitres <= 0)
	    throw new ArgumentException(InvalidFuelAmount);
	if (fuelAmountInLitres > TankCapacityInLitres)
	    throw new InvalidOperationException(String.Format(ExcessiveFuelAmount, fuelAmountInLitres));
	return true;
    }

    public override string ToString()
    {
	return $"{GetType().Name}: {FuelReservesInLitres:F2}";
    }
}
