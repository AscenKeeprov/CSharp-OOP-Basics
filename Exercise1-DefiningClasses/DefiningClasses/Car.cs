public class Car
{
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumptionPerKm { get; set; }
    public double DistanceTraveled { get; set; }

    public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
    {
	Model = model;
	FuelAmount = fuelAmount;
	FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public Car TryDrive(Car car, double distance)
    {
	double projectedFuelLoss = distance * car.FuelConsumptionPerKm;
	if (projectedFuelLoss <= car.FuelAmount)
	{
	    car.FuelAmount -= projectedFuelLoss;
	    car.DistanceTraveled += distance;
	}
	else System.Console.WriteLine("Insufficient fuel for the drive");
	return car;
    }
}
