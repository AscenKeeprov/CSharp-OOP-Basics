using System;

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public Tire[] Tires { get; set; }
    public Cargo Cargo { get; set; }

    public Car()
    {
	Model = "Unfinished";
	Engine = new Engine();
	Tires = new Tire[4];
	Cargo = new Cargo();
    }

    public Car(string model, Engine engine, Tire[] tires, Cargo cargo)
    {
	Model = model;
	Engine = engine;
	Array.Copy(tires, Tires, tires.Length);
	Cargo = cargo;
    }
}
