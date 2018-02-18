using System;
using System.Collections.Generic;
using System.Linq;

class RawData
{
    static void Main()
    {
	Worker worker = new Worker();
	List<Car> cars = new List<Car>();
	int carsCount = int.Parse(Console.ReadLine());
	for (int c = 1; c <= carsCount; c++)
	{
	    string[] carInfo = Console.ReadLine().Split();
	    Car car = AssembleCar(worker, carInfo);
	    cars.Add(car);
	}
	string filterByCargoType = Console.ReadLine();
	PrintReport(cars, filterByCargoType);
    }

    private static Car AssembleCar(Worker worker, string[] carInfo)
    {
	Car car = new Car();
	car.Model = carInfo[0];
	car.Engine = worker.AssembleEngine(carInfo);
	car.Tires = worker.MountTires(carInfo);
	car.Cargo = worker.LoadCargo(carInfo);
	return car;
    }

    private static void PrintReport(List<Car> cars, string cargoType)
    {
	if (cargoType.ToUpper() == "FRAGILE")
	{
	    List<string> carsWithFragileCargo = cars.Where(
		car => car.Cargo.Type == "fragile" &&
		car.Tires.Any(tire => tire.Pressure < 1))
		.Select(car => car.Model).ToList();
	    Console.WriteLine(String.Join(Environment.NewLine, carsWithFragileCargo));
	}
	else if (cargoType.ToUpper() == "FLAMABLE")
	{
	    List<string> carsWithFlammableCargo = cars.Where(
		car => car.Cargo.Type == "flamable" &&
		car.Engine.Power > 250).Select(car => car.Model).ToList();
	    Console.WriteLine(string.Join(Environment.NewLine, carsWithFlammableCargo));
	}
    }
}
