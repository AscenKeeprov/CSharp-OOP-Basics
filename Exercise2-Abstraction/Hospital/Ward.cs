using System;
using System.Collections.Generic;

public class Ward
{
    public string Name { get; set; }
    public Room[] Rooms { get; set; }
    public List<Patient> Patients { get; set; }

    public Ward()
    {
	Name = String.Empty;
	Rooms = new Room[20];
	for (int room = 0; room < Rooms.Length; room++)
	{
	    Rooms[room] = new Room() { Number = room + 1 };
	}
	Patients = new List<Patient>();
    }

    public Ward(string name) : this()
    {
	Name = name;
    }
}
