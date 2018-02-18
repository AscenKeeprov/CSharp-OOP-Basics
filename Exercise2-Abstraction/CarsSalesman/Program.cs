using System;
using System.Collections.Generic;
using System.Linq;

class CarSalesman
{
    static void Main()
    {
	List<Car> cars = new List<Car>();
	List<Engine> engines = new List<Engine>();
	int enginesCount = int.Parse(Console.ReadLine());
	for (int e = 1; e <= enginesCount; e++)
	{
	    string[] engineInfo = Console.ReadLine().Trim().Split();
	    Engine engine = AssembleEngine(engineInfo);
	    engines.Add(engine);
	}
	int carsCount = int.Parse(Console.ReadLine());
	for (int c = 1; c <= carsCount; c++)
	{
	    string[] carInfo = Console.ReadLine().Trim().Split();
	    Car car = AssembleCar(carInfo, engines);

	    cars.Add(car);
	}
	foreach (Car car in cars) Console.WriteLine(car);
    }

    private static Engine AssembleEngine(string[] engineInfo)
    {
	string model = engineInfo[0];
	int power = int.Parse(engineInfo[1]);
	Engine engine = new Engine(model, power);
	if (engineInfo.Length >= 3)
	{
	    if (int.TryParse(engineInfo[2], out int displacement))
		engine.Displacement = displacement;
	    else engine.Efficiency = engineInfo[2];
	    if (engineInfo.Length == 4)
	    {
		if (int.TryParse(engineInfo[2], out displacement))
		    engine.Efficiency = engineInfo[3];
		else engine.Displacement = int.Parse(engineInfo[3]);
	    }
	}
	return engine;
    }

    private static Car AssembleCar(string[] carInfo, List<Engine> engines)
    {
	string model = carInfo[0];
	Engine engine = engines.First(e => e.Model == carInfo[1]);
	Car car = new Car(model, engine);
	if (carInfo.Length >= 3)
	{
	    if (int.TryParse(carInfo[2], out int weight))
		car.Weight = weight;
	    else car.Color = carInfo[2];
	    if (carInfo.Length == 4)
	    {
		if (int.TryParse(carInfo[2], out weight))
		    car.Color = carInfo[3];
		else car.Weight = int.Parse(carInfo[3]);
	    }
	}
	return car;
    }
}
