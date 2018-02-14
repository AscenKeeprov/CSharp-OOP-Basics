using System;

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public int Weight { get; set; }
    public string Color { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumptionPerKm { get; set; }
    public double DistanceTraveled { get; set; }

    public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
    {
	Model = model;
	FuelAmount = fuelAmount;
	FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public Car(string model, Engine engine)
    {
	Model = model;
	Engine = engine;
    }

    public Car TryDrive(Car car, double distance)
    {
	double projectedFuelLoss = distance * car.FuelConsumptionPerKm;
	if (projectedFuelLoss <= car.FuelAmount)
	{
	    car.FuelAmount -= projectedFuelLoss;
	    car.DistanceTraveled += distance;
	}
	else Console.WriteLine("Insufficient fuel for the drive");
	return car;
    }

    public override string ToString()
    {
	string weight = "n/a";
	if (Weight != 0) weight = Weight.ToString();
	string color = "n/a";
	if (Color != null) color = Color;
	return $"{Model}:{Environment.NewLine}" +
	    $"  {Engine.ToString()}{Environment.NewLine}" +
	    $"  Weight: {weight}{Environment.NewLine}" +
	    $"  Color: {color}";
    }
}
