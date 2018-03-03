using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
	Nature.currentSeason = ESeason.Summer;
	VehicleFactory vehicleFactory = new VehicleFactory();
	List<Vehicle> garage = new List<Vehicle>();
	int vehicleCount = 3;
	ObtainVehicles(vehicleFactory, vehicleCount, garage);
	UseVehicles(garage);
	CheckOnVehicles(garage);
    }

    private static void ObtainVehicles(VehicleFactory vehicleFactory, int vehicleCount, List<Vehicle> garage)
    {
	for (int v = 0; v < vehicleCount; v++)
	{
	    try
	    {
		string[] vehicleInfo = Console.ReadLine().Split();
		Vehicle vehicle = vehicleFactory.Produce(vehicleInfo);
		garage.Add(vehicle);
	    }
	    catch { }
	}
    }

    private static void UseVehicles(List<Vehicle> garage)
    {
	int commandCount = int.Parse(Console.ReadLine());
	for (int c = 1; c <= commandCount; c++)
	{
	    try
	    {
		string[] command = Console.ReadLine().Trim().Split();
		string action = command[0].ToUpper();
		string vehicleType = command[1];
		Vehicle vehicle = garage.FirstOrDefault(v => v.GetType().Name == vehicleType);
		if (action.StartsWith("DRIVE"))
		{
		    double distance = double.Parse(command[2]);
		    if (action.Equals("DRIVE")) vehicle.Drive(distance, true);
		    else if (action.Equals("DRIVEEMPTY"))
			((Bus)vehicle).Drive(distance, false);
		}
		else if (action.Equals("REFUEL"))
		{
		    double fuelAmount = double.Parse(command[2]);
		    vehicle.Refuel(fuelAmount);
		}
	    }
	    catch (Exception exception)
	    {
		if (exception is ArgumentException || exception is InvalidOperationException)
		    Console.WriteLine(exception.Message);
	    }
	}
    }

    private static void CheckOnVehicles(List<Vehicle> garage)
    {
	foreach (Vehicle vehicle in garage)
	{
	    Console.WriteLine(vehicle);
	}
    }
}
