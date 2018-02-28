using System;

public abstract class Car : ICar
{
    public virtual string Model { get; set; }
    public string Driver { get; set; }

    public void PushBrakes()
    {
	Console.Write("Brakes!");
    }

    public void PushGasPedal()
    {
	Console.Write("Zadu6avam sA!");
    }
}
