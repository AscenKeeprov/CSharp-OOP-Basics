using System;
using System.Globalization;

public class VehicleFactory
{
    private const string InvalidVehicleType = "Factory does not produce this type of vehicle!";
    TextInfo textInfo = new CultureInfo("", true).TextInfo;

    internal Vehicle Produce(string[] vehicleInfo)
    {
	string vehicleType = textInfo.ToTitleCase(vehicleInfo[0]);
	Type typeOfVehicle = Type.GetType(vehicleInfo[0]);
	double fuelQuantuty = double.Parse(vehicleInfo[1]);
	double fuelConsumption = double.Parse(vehicleInfo[2]);
	double tankCapacity = double.Parse(vehicleInfo[3]);
	Vehicle vehicle = (Vehicle)Activator.CreateInstance(typeOfVehicle, fuelQuantuty, fuelConsumption, tankCapacity);
	return vehicle;
    }
}
