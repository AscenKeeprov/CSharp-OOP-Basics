using System.Collections.Generic;

public class Hospital
{
    public List<Ward> Wards { get; set; }
    public List<Doctor> Staff { get; set; }

    public Hospital()
    {
	Wards = new List<Ward>();
	Staff = new List<Doctor>();
    }
}
