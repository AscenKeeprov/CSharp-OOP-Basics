public class Worker
{
    public Engine AssembleEngine(string[] carInfo)
    {
	int enginePower = int.Parse(carInfo[2]);
	int engineSpeed = int.Parse(carInfo[1]);
	Engine engine = new Engine(enginePower, engineSpeed);
	return engine;
    }

    public Cargo LoadCargo(string[] carInfo)
    {
	string cargoType = carInfo[4];
	int cargoWeight = int.Parse(carInfo[3]);
	Cargo cargo = new Cargo(cargoType, cargoWeight);
	return cargo;
    }

    internal Tire[] MountTires(string[] carInfo)
    {
	Tire[] tires = new Tire[4]
	{
	    new Tire(), new Tire(), new Tire(), new Tire()
	};
	tires[0].Pressure = double.Parse(carInfo[5]);
	tires[0].Age = int.Parse(carInfo[6]);
	tires[1].Pressure = double.Parse(carInfo[7]);
	tires[1].Age = int.Parse(carInfo[8]);
	tires[2].Pressure = double.Parse(carInfo[9]);
	tires[2].Age = int.Parse(carInfo[10]);
	tires[3].Pressure = double.Parse(carInfo[11]);
	tires[3].Age = int.Parse(carInfo[12]);
	return tires;
    }
}
