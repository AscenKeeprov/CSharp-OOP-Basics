using System.Collections.Generic;

public class Doctor
{
    public string Name { get; set; }
    public List<Patient> Patients { get; set; }

    public Doctor()
    {
	Patients = new List<Patient>();
    }

    public Doctor(string name) : this()
    {
	Name = name;
    }
}
